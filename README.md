# ✨ Entity Framework ile ASP.NET Core MVC Kurs Yönetim Sistemi

Bu proje, **ASP.NET Core MVC** ve **Entity Framework Core** kullanılarak geliştirilmiş bir **Kurs Yönetim Sistemi**dir. Sistem, kursları, öğrencileri ve öğretmenleri yönetmeyi sağlayan bir yapıya sahiptir.

## 📌 Proje Özeti

Bu proje, eğitim kurumları için geliştirilmiş bir **Kurs Yönetim Sistemi**dir. Kullanıcılar aşağıdaki işlemleri gerçekleştirebilir:

![navbar](https://github.com/user-attachments/assets/88ee44eb-819f-4e30-8133-8046df3a7573)

✅ **Kurs Yönetimi**: Kursları ekleyebilir, düzenleyebilir ve silebilirler.  
![kursliste](https://github.com/user-attachments/assets/31dae09a-afec-4947-9a01-ff26ad913741)
![kursekle](https://github.com/user-attachments/assets/38e0c5b4-04ee-444c-ba0b-45e01b2d5d5a)

✅ **Öğrenci Yönetimi**: Öğrencileri ekleyebilir ve hangi kurslara kayıt olduklarını görebilirler.  
![ogrenciliste](https://github.com/user-attachments/assets/7e5eed69-87af-4a55-8102-51857a4d3136)
![ogrenciguncelle](https://github.com/user-attachments/assets/f40d583a-f24c-4a4b-ac7a-156213a506dd)

✅ **Öğretmen Yönetimi**: Öğretmenleri kurslara atayabilirler.  
![ogretmenliste](https://github.com/user-attachments/assets/ec61091f-411c-4695-846c-d6a482feaa46)
![ogretmenekle](https://github.com/user-attachments/assets/fe41cb20-937d-4407-8cae-42c45d589cdd)

✅ **Kurs Kayıtları**: Öğrencilerin kurslara kayıtlarını yönetebilirler.  
![kurskayitliste](https://github.com/user-attachments/assets/ca1b4406-21d3-4df3-8f96-4a08cab0af48)
![kurskayitekle](https://github.com/user-attachments/assets/f56bdbe3-d16f-404f-8b94-b33a14c0fb6c)

Bu sistem, **MVC mimarisi** ve **Repository Pattern** kullanılarak **modüler ve sürdürülebilir** bir yapı ile geliştirilmiştir.

---

## 🔧 Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|-----------|---------|
| **ASP.NET Core MVC** | Modern web uygulaması geliştirme çerçevesi |
| **Entity Framework Core** | ORM (Object-Relational Mapping) yapısı |
| **SQL Server / SQLite** | Veritabanı yönetimi |
| **LINQ** | Veri sorgulama işlemleri |
| **Dependency Injection** | Bağımlılık yönetimi |
| **Repository Pattern** | Daha temiz ve sürdürülebilir kod yapısı |

---

## ⚙️ Kurulum

Projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izleyin:

```sh
# 1️⃣ Projeyi klonlayın
git clone https://github.com/kullaniciadi/KursYonetimSistemi.git

# 2️⃣ Proje klasörüne girin
cd KursYonetimSistemi

# 3️⃣ Bağımlılıkları yükleyin
dotnet restore

# 4️⃣ Veritabanını güncelleyin
dotnet ef database update

# 5️⃣ Uygulamayı çalıştırın
dotnet run
