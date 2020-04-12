using PhoneShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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

        public Member GetMember(string UserId)
        {
            using (var context = new PhoneShopContext())
            {
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