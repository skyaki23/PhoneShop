# ASP.NET MVC 練習作品 - PhoneShop 手機商店

* 利用ASP.NET MVC技術製作手機購物網站。
* Model建立物件的屬性，再用Code First方式先建立DbContext類別傳入資料庫連接字串，透過套件管理器主控台執行資料庫移轉，完成資料庫建置。
* ViewModel建立用於Controller及View的物件屬性。
* Service中建立各個獨立與資料庫利用LINQ等技術做資料增刪改查等行為的function，給予Controller呼叫使用。
* Controller透過前端View的RenderAction、Action等請託找到對應的Controller function後，利用Service中與資料庫做溝通的function，完成所需行為或是得到物件屬性資料給與建立完的ViewModel物件用於View上。
* View可藉由Razor語法將Controller傳遞至的ViewModel屬性資料繫節渲染至頁面上或是條件及迴圈等處理，而頁面上的元素可透過JavaScript做與前端的互動以及利用Ajax資料傳遞給Controller，完成所需行為。
* 資料為非營利、非商業用途所使用，僅為個人學習技術所使用。

## 網站連結
* https://phoneshopmvc2020.azurewebsites.net/

### 開發環境
* Visual Studio 2019
    
### 使用技術
* ASP.NET MVC
* Entity Framework – Code First
* C#
* HTML
* CSS
* Bootstrap
* JavaScript
* JQuery
* AJAX
* LINQ
* SQL Server
* github

### 作品介紹
### 1.首頁
* 輪播圖顯示最新上傳產品
* 顯示產品資訊並帶有加入購物車按鈕
* 產品可依照條件(搜尋關鍵字、產品排序、品牌查詢、價錢)做顯示
* 產品分頁

![Imgur](https://i.imgur.com/G2Wl0dK.png)
![Imgur](https://i.imgur.com/pr4voTL.png)
![Imgur](https://i.imgur.com/7wvAHez.png)

---

### 2.購物車頁面
* 顯示加入購物車產品詳細資訊、購買數量及總價

![Imgur](https://i.imgur.com/0AdwRwq.png)

---

### 3.產品品牌頁面
* 管理者做產品品牌的增刪改查
* 顯示產品品牌已上傳的產品

![Imgur](https://i.imgur.com/l17XhuC.png)

---

### 4.產品頁面
* 管理者做產品的增刪改查
* 顯示產品詳細資訊

![Imgur](https://i.imgur.com/Ak3IxZJ.png)
![Imgur](https://i.imgur.com/5gNYNO1.png)

---

### 5.訂單頁面
* 顯示所有會員所下訂的訂單
* 管理者修改訂單狀態的功能

![Imgur](https://i.imgur.com/51IsMtj.png)
