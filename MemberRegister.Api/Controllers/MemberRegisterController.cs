using AutoMapper;
using MemberRegister.Api.Services;
using MemberRegister.Core.Dto;
using MemberRegister.Core.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemberRegister.Api.Controllers
{
    [EnableCors("MemberRegisterPolicy")]
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class MemberRegisterController : BaseController //ControllerBase
    {
        /// <summary>
        /// Reference to the service
        /// </summary>
        private readonly IMemberRegisterService m_MemberRegisterService;

        /// <summary>
        /// Reference to automapper
        /// </summary>
        public readonly IMapper m_Mapper;

        /// <summary>
        /// Reference to a logger
        /// </summary>
        private readonly ILogger<MemberRegisterController> m_Logger;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Refence to member register service</param>
        /// <param name="mapper">Reference to automapper</param>
        /// <param name="logger">Reference to a logger</param>
        public MemberRegisterController(IMemberRegisterService service, IMapper mapper,  ILogger<MemberRegisterController> logger)
        {
            this.m_MemberRegisterService = service;
            this.m_Mapper = mapper;
            this.m_Logger = logger;
        }


        /// <summary>
        /// GET: api/<MemberController>
        /// Get all members
        /// </summary>
        /// <returns>Ok = 200. List with members</returns>
        /// <response code="200">List with members</response>
        /// <response code="500">Exception</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MemberDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetMembers")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetMembers()
        {
            List<MemberDto>? lsMembersDto = null;

            try
            {
                var members = await this.m_MemberRegisterService.GetMembersAsync();

                if(members != null && members.Count() > 0)
                {
                    lsMembersDto = new List<MemberDto>(members.Count());
                    MemberDto? dto = null;

                    // Map entities to dto
                    foreach(Member member in members) {
                        dto = m_Mapper.Map<MemberDto>(member);
                        if(dto != null)
                            lsMembersDto.Add(dto);
                    }
                }
            }
            catch(Exception ex)
            {
                this.m_Logger.LogError(ex.ToString());
                return StatusCode(500, "Error reading members");
            }

            return Ok(lsMembersDto);
        }


        /// <summary>
        /// GET api/<MemberController>/5
        /// Get a member
        /// </summary>
        /// <param name="id">id for member</param>
        /// <returns>Ok = 200 and the searched member or NotFound = 404</returns>
        /// <response code="200">Return the searched member</response>
        /// <response code="404">Dident find member with id</response>
        /// <response code="500">Exception</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MemberDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetMember/{id}")]
        public async Task<ActionResult<MemberDto>> GetMember(int id)
        {
            MemberDto? memberDto = null;

            try
            {
                Member member = await this.m_MemberRegisterService.GetMemberAsync(id);

                if(member != null)
                {
                    memberDto = m_Mapper.Map<MemberDto>(member);
                }
                else
                {
                    return NotFound($"Cant find member with id = {id}");
                }
            }
            catch(Exception ex) 
            {
                this.m_Logger.LogError(ex.ToString());
                return StatusCode(500, "Error reading member");
            }
            
            return Ok(memberDto);
        }


        /// <summary>
        /// POST api/<MemberController>
        /// Create a new member
        /// </summary>
        /// <param name="memberDto">Object with information about the new member</param>
        /// <returns></returns>
        /// <response code="201">Created a new member</response>
        /// <response code="400">No indata or invalid model</response>
        /// <response code="500">Exception or cant create member</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MemberDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("CreateMember")]
        public async Task<ActionResult<MemberDto>> PostMember([FromBody]MemberDto memberDto)
        {
            if (memberDto == null)
                return BadRequest("No information about member in the request");

            if (!ModelState.IsValid)
                return BadRequest("Invalid model");

            try
            {
                Member member = m_Mapper.Map<Member>(memberDto);
                bool bIsSaveOk = await this.m_MemberRegisterService.CreateMemberAsync(member);

                if (!bIsSaveOk)
                    return StatusCode(500, "Cant create member");
            }
            catch (Exception ex)
            {
                this.m_Logger.LogError(ex.ToString());
                return StatusCode(500, "Error creating member");
            }

            return CreatedAtAction("GetMember", new { id = memberDto.Id }, memberDto);
        }


        /// <summary>
        /// PUT api/<MemberController>/5
        /// Update information about a member
        /// </summary>
        /// <param name="id">Id for member</param>
        /// <param name="memberDto">Information om the member</param>
        /// <returns></returns>        
        /// <response code="200">If we updated information about a member</response>
        /// <response code="400">No indata or Member id dosent match</response>
        /// <response code="500">Exception or cant update information about member</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("UpdateMember/{id}")]
        public async Task<ActionResult> UpdateMember(int id, [FromBody] MemberDto memberDto)
        {
            if (memberDto == null)
                return BadRequest("No information about member in the request");

            if (id != memberDto.Id)
                return BadRequest("Member id dosent match");

            try 
            {
                Member member = m_Mapper.Map<Member>(memberDto);
                bool bIsUpdateOk = await this.m_MemberRegisterService.UpdateMemberAsync(id, member);

                if (!bIsUpdateOk)
                    return StatusCode(500, "Cant update member");
            }
            catch (Exception ex) 
            {
                this.m_Logger.LogError(ex.ToString());
                return StatusCode(500, "Error updating member");
            }

            return Ok();            
        }


        /// <summary>
        /// DELETE api/<MemberController>/5
        /// Delete a member
        /// </summary>
        /// <param name="id">Id for member that we want to delete</param>
        /// <returns></returns>
        /// <response code="200">If we deleted a member</response>
        /// <response code="500">Exception or cant delete a member</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("DeleteMember/{id}")]
        public async Task<ActionResult> DeleteMember(int id)
        {
            try 
            {
                bool bIsDeletingOk = await this.m_MemberRegisterService.DeleteMemberAsync(id);
                if(!bIsDeletingOk)
                    return StatusCode(500, "Cant delete member");
            }
            catch(Exception ex)
            {
                this.m_Logger.LogError(ex.ToString());
                return StatusCode(500, "Error deleting member");
            }

            return Ok();            
        }


        [HttpGet("GetCoffe")]
        public async Task<ActionResult> BrewCoffe()
        {
            // 418 I'm a teapot
            // The server refuses the attempt to brew coffee with a teapot.
            return StatusCode(418);
        }
    }
}
