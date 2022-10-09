using MemberRegister.Core.Entities;

namespace MemberRegister.Core.Repositories
{
    /// <summary>
    /// Interface for the MemberRegisterRepository
    /// </summary>
    public interface IMemberRegisterRepository
    {
        Task<bool> CreateMemberAsync(Member member);
        Task<bool> DeleteMemberAsync(int id);
        Task<IEnumerable<Member>> GetMembersAsync();
        Task<Member> GetMemberAsync(int id);
        Task<bool> UpdateMemberAsync(int id, Member member);
    }
}
