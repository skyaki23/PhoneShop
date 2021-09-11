using PhoneShop.Models;
using System.Linq;

namespace PhoneShop.Services
{
    public class MemberService
    {
        #region Singleton
        public static MemberService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MemberService();
                }
                return instance;
            }
        }
        private static MemberService instance { get; set; }
        private MemberService()
        {

        }
        #endregion

        /// <summary>
        /// 回傳會員資訊
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Member GetMember(string UserId)
        {
            using (var context = new PhoneShopContext())
            {
                //若未查詢到該筆會員資料，預設回傳null
                return context.Members.Where(x => x.UserId == UserId).FirstOrDefault();
            }
        }

        public Member LoginMember(string UserId, string UserPassword)
        {
            using (var context = new PhoneShopContext())
            {
                return context.Members.Where(x => x.UserId == UserId && x.UserPassword == UserPassword).FirstOrDefault();
            }
        }

        public void SaveMember(Member member)
        {
            using (var context = new PhoneShopContext())
            {
                context.Members.Add(member);
                context.SaveChanges();
            }
        }
    }
}