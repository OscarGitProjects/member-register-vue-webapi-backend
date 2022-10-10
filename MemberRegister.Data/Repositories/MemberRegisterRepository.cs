using MemberRegister.Core.Entities;
using MemberRegister.Core.Repositories;
using MemberRegister.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace MemberRegister.Data.Repositories
{
    /// <summary>
    /// Repository class
    /// </summary>
    public class MemberRegisterRepository : IMemberRegisterRepository
    {
        /// <summary>
        /// Reference to db context
        /// </summary>
        private readonly ApplicationDbContext m_Context;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Reference to a db context</param>
        public MemberRegisterRepository(ApplicationDbContext context)
        {
            this.m_Context = context;
        }

      
        /// <summary>
        /// Method save a information about a new member to the repository
        /// </summary>
        /// <param name="member">New member</param>
        /// <returns>true if we can create a new member else we return false</returns>
        /// <exception cref="ArgumentNullException">Thrown when reference to member is null</exception>
        public async Task<bool> CreateMemberAsync(Member member)
        {
            if (member == null)
                throw new ArgumentNullException($"{nameof(MemberRegisterRepository)}->CreateMemberAsync(). Reference to member is null");

            DateTime dtNow = DateTime.Now;
            member.CreationDate = dtNow;
            member.LastUpdatedDate = dtNow;

            await this.m_Context.Member.AddAsync(member);

            int numberOfCreated = await this.m_Context.SaveChangesAsync();
            if (numberOfCreated > 0)
                return true;

            return false;
        }


        /// <summary>
        /// Method remove a member from repository
        /// </summary>
        /// <param name="id">Id for member that shall be removed</param>
        /// <returns>true if we removed a member else we return false</returns>
        public async Task<bool> DeleteMemberAsync(int id)
        {
            Member member = await GetMemberAsync(id);
            if(member != null)
            {
                this.m_Context.Member.Remove(member);

                int numberOfRemoved = await this.m_Context.SaveChangesAsync();
                if (numberOfRemoved > 0)
                    return true;
            }
            
            return false;
        }


        /// <summary>
        /// Method return all members in repository
        /// </summary>
        /// <returns>IEnumerable with members</returns>
        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await m_Context.Member.AsNoTracking().ToListAsync();
        }


        /// <summary>
        /// Method return member with id
        /// </summary>
        /// <param name="id">Id for member we search for</param>
        /// <returns>Member</returns>
        public async Task<Member> GetMemberAsync(int id)
        {
            return await m_Context.Member.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }


        /// <summary>
        /// Method update information about a member
        /// </summary>
        /// <param name="id">Id for member</param>
        /// <param name="member">Member object with information</param>
        /// <returns>true if we updated a member else we return false</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<bool> UpdateMemberAsync(int id, Member member)
        {
            if (member == null)
                throw new ArgumentNullException($"{nameof(MemberRegisterRepository)}->UpdateMemberAsync(). Reference to member is null");

            DateTime dtNow = DateTime.Now;
            member.CreationDate = dtNow;
            member.LastUpdatedDate = dtNow;

            var oldMember = await m_Context.Member.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            // We should always have a old member
            if (oldMember != null)
                member.CreationDate = oldMember.CreationDate;

            m_Context.Member.Update(member);

            int numberOfUpdated = await this.m_Context.SaveChangesAsync();
            if (numberOfUpdated > 0)
                return true;

            return false;
        }
    }
}
