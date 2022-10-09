using MemberRegister.Core.Entities;
using MemberRegister.Core.Repositories;

namespace MemberRegister.Api.Services
{
    public class MemberRegisterService : IMemberRegisterService
    {
        /// <summary>
        /// Reference to the repository
        /// </summary>
        private readonly IMemberRegisterRepository m_Repository;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Reference to the repository</param>
        public MemberRegisterService(IMemberRegisterRepository repository)
        {
            this.m_Repository = repository;
        }


        /// <summary>
        /// Method create a new Member
        /// </summary>
        /// <param name="member">Member with information about the new member</param>
        /// <returns>true if we could create a new member else we return false</returns>
        /// <exception cref="ArgumentNullException">Exception is thrown if reference to member is null</exception>
        /// <exception cref="Exception">Exception from the repository</exception>
        public async Task<bool> CreateMemberAsync(Member member)
        {
            if(member == null) 
                throw new ArgumentNullException($"{nameof(MemberRegisterService)}->CreateMemberAsync(). Reference to member is null");

            return await this.m_Repository.CreateMemberAsync(member);
        }


        /// <summary>
        /// Method delete a member
        /// </summary>
        /// <param name="id">Id for member we want to delete</param>
        /// <returns>true if we could delete member else we return false</returns>
        /// <exception cref="Exception">Exception from the repository</exception>
        public async Task<bool> DeleteMemberAsync(int id)
        {
            return await this.m_Repository.DeleteMemberAsync(id);
        }


        /// <summary>
        /// Method return a member
        /// </summary>
        /// <param name="id">Id for member we ar searching for</param>
        /// <returns>Member or null</returns>
        /// <exception cref="Exception">Exception from the repository</exception>
        public async Task<Member> GetMemberAsync(int id)
        {
            return await this.m_Repository.GetMemberAsync(id);
        }


        /// <summary>
        /// Method return a list of members
        /// </summary>
        /// <returns>IEnumerable with members</returns>
        /// <exception cref="Exception">Exception from the repository</exception>
        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await this.m_Repository.GetMembersAsync();
        }


        /// <summary>
        /// Method updates information about a member
        /// </summary>
        /// <param name="id">Members id</param>
        /// <param name="member">Member object with new information about member</param>
        /// <returns>true if we could update member else we return false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception">Exception from the repository</exception>
        public async Task<bool> UpdateMemberAsync(int id, Member member)
        {
            if (member == null)
                throw new ArgumentNullException($"{nameof(MemberRegisterService)}->UpdateMemberAsync(). Reference to member is null");

            return await this.m_Repository.UpdateMemberAsync(id, member);
        }
    }
}
