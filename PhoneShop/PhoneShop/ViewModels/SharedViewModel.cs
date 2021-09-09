using System;

namespace PhoneShop.ViewModels
{
    public class Pager
    {
        /// <summary>
        /// 產品分頁功能
        /// </summary>
        /// <param name="totalItems">產品數量</param>
        /// <param name="page">顯示的產品頁碼</param>
        /// <param name="pageSize">一頁中所顯示的產品數量(此預設為10)</param>
        public Pager(int totalItems, int? page, int pageSize = 10)
        {
            //若傳入為0，則設將一頁中所顯示的產品數量為10
            if (pageSize == 0) {
                pageSize = 10;
            }

            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize); // Ceiling使取大、等於其整數值，為共有的頁數，e.g.25/6=4.1667，故為5頁
            var currentPage = page != null ? (int)page : 1; // 若顯示的產品頁碼不為null，則取其值為目前頁碼，否則預設目前頁碼為1
            var startPage = currentPage - 5; // 設定起始的頁碼，若currentPage=1，則startPage=-4
            var endPage = currentPage + 4; // 設定最終的頁碼，若currentPage=1，則endPage=5，與startPage差距為10

            //若startPage小、等於0時，發生於目前顯示的產品頁碼在第1~5頁時
            if (startPage <= 0)
            {
                endPage -= (startPage - 1); // 設定最終頁碼為endPage-(startPage -1)，e.g. endPage=5、startPage=-4，
                                            // 則會為，endPage = 5-(-4-1) = 5-(-5) = 10
                startPage = 1; // 設定起始頁碼為第1頁
            }
            //若endPage大於totalPages(共有的頁數)
            if (endPage > totalPages)
            {
                //則設endPage等於totalPages即為最終頁碼，因endPage不該超過最終頁碼
                endPage = totalPages;

                //而若endPage大於10
                if (endPage > 10)
                {
                    //則設起始頁碼為最終頁碼-9，e.g. endPage=11則startPage=2，差距為10頁
                    startPage = endPage - 9;
                }
            }

            //設定屬性值
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        /// <summary>
        /// 產品數量
        /// </summary>
        public int TotalItems { get; private set; }
        /// <summary>
        /// 顯示的產品頁碼
        /// </summary>
        public int CurrentPage { get; private set; }
        /// <summary>
        /// 一頁中所顯示的產品數量
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// 共有的頁數
        /// </summary>
        public int TotalPages { get; private set; }
        /// <summary>
        /// 起始頁碼
        /// </summary>
        public int StartPage { get; private set; }
        /// <summary>
        /// 最終頁碼
        /// </summary>
        public int EndPage { get; private set; }
    }
}