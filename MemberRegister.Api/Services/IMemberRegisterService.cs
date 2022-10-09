using MemberRegister.Core.Entities;

namespace MemberRegister.Api.Services
{
    /// <summary>
    /// Interface for MemberRegisterService
    /// </summary>
    public interface IMemberRegisterService
    {
        Task<IEnumerable<Member>> GetMembersAsync();
        Task<Member> GetMemberAsync(int id);
        Task<bool> DeleteMemberAsync(int id);
        Task<bool> UpdateMemberAsync(int id, Member member);
        Task<bool> CreateMemberAsync(Member member);
    }
}
