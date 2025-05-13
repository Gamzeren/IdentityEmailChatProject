# 💌 Identity Email Chat Project
ASP.NET Core MVC ile geliştirilmiş, kullanıcı kimlik doğrulama **(Identity)** sistemi entegre bir e-posta mesajlaşma uygulamasıdır. Kullanıcılar sisteme kayıt olup giriş yaptıktan sonra birbirlerine mesaj gönderip alabilir, gelen ve giden mesajlarını görebilir, profil bilgilerini güncelleyebilirler.
## 🎯 Projenin Amacı
Bu proje, ASP.NET Core'un Identity sistemi ve Entity Framework Core kullanılarak geliştirilen temel bir mesajlaşma (e-mail) sistemini örneklemektedir. Amaç, kullanıcı kayıt/giriş süreçlerinin yanında, basit bir mesajlaşma altyapısını uygulamak ve bu süreçte kullanıcı arayüzünü şık bir tasarımla bütünleştirmektir.
## ⚒️ Kullanılan Teknolojiler
💎 ASP.NET Core MVC </br>
💎 Entity Framework Core </br>
💎 ASP.NET Core Identity </br>
💎 MS SQL Server </br>
💎 SweetAlert </br>
## 🚀 Özellikler
👤 Kullanıcı kayıt, giriş ve çıkış işlemleri </br>
✉️ Yeni mesaj gönderme </br>
📥 Gelen mesaj kutusu </br>
📤 Giden mesaj kutusu </br>
🗑️ Mesajları çöp kutusuna taşıma </br>
🛠 Profil bilgilerini güncelleme </br>
✅ SweetAlert2 ile başarılı işlem bildirimleri </br>
📊 Bootstrap tabanlı responsive ve modern tasarım </br>

## 📃 Sayfa Yapısı
### 👤 Register Sayfası
📲 Kullanıcı burada kayıt olur, bilgiler veritabanına eklenir. </br>
🔐 Şifreler hash’lenerek saklanır. </br>
❌ Doğru şifre oluşturulması için Validator ile kurallar belirtilir. </br>

![Image](https://github.com/user-attachments/assets/1fb7acbd-25ba-4aca-a8b3-938ffebd8938)

### 🔑 Login Sayfası
👤 Kullanıcı bilgileri ile giriş yapar. </br>
🚫 5 defa yanlış girişte, 5 dakika boyunca giriş yapılamaz. </br>

![Image](https://github.com/user-attachments/assets/022c7607-a984-4ea4-b5f4-ba4f2dbd69f3)

### 💠 Profilim
📝 Kullanıcı adı, soyadı, e-posta, kullanıcı adı ve profil fotoğrafı gösterilir. </br>
📊 Gönderilen & alınan mesaj sayısı count ile hesaplanır. </br>
🛠️ Tüm bilgiler güncellenebilir. </br>

![Image](https://github.com/user-attachments/assets/ae203107-7384-49d5-95ad-2bf4956c72a1)

### 📥 Gelen Kutusu & 📤 Giden Kutusu
📬 Kullanıcı, gelen/giden mesajlarını görüntüleyebilir.  </br>
🔎 Arama Çubuğu ile filtreleme yapılabilir.  </br>
🔄 Mesaj çöp kutusuna gönderilir.  </br>
🔢 Sidebar’daki gelen mesaj sayısı dinamik olarak güncellenir.  </br>

![Image](https://github.com/user-attachments/assets/44dde150-b8c7-45cc-91bf-b788f6231aa3)

![Image](https://github.com/user-attachments/assets/adbfb1b8-b561-476a-8c99-e542dbb55eda)

![Image](https://github.com/user-attachments/assets/0db7eebe-7c6c-4f73-8729-003455cc45a7)

### 📨 Yeni Mesaj Ekleme
📧 Alıcının e-posta adresi, konu ve mesaj içeriği girilir. </br>
✅ Gönderim sonrası SweetAlert ile başarı mesajı gösterilir. </br>

![Image](https://github.com/user-attachments/assets/2b51542f-b92e-4a36-af7d-f56f37f6516b)

![Image](https://github.com/user-attachments/assets/cf5b7413-32f4-45c9-917e-b75bbb0f1fa2)
