# 💬 ỨNG DỤNG CHAT LAN – C# WinForms

Ứng dụng Chat nội bộ (LAN Chat) hỗ trợ giao tiếp nhanh chóng giữa các máy tính trong cùng mạng cục bộ. Giao diện thân thiện, tốc độ phản hồi nhanh và đầy đủ tính năng trò chuyện cá nhân và nhóm.

---

## 🚀 TÍNH NĂNG CHÍNH

- 👤 Đăng nhập / Đăng xuất với tài khoản có sẵn (Hiện chỉ dùng để đăng nhập)
- 🟢 Hiển thị danh sách người dùng online
- 💬 Trò chuyện 1-1 (Private Chat)
- 👥 Trò chuyện nhóm (Group Chat)
- 📢 Thông báo khi có người tham gia hoặc rời nhóm
- 🔔 Gửi tin nhắn theo thời gian thực
- 🛠️ Tạo / tham gia / rời nhóm chat
- ✅ Quản lý kết nối máy khách qua socket TCP đa luồng 

---

## 🏗️ KIẾN TRÚC ỨNG DỤNG

- **Mô hình 3 lớp**: UI ⟶ BLL ⟶ DAL ⟶ MySQL
- **Giao tiếp mạng**: Socket TCP (client-server)
- **Lưu trữ**: Cơ sở dữ liệu MySQL

---

## 🔧 CÀI ĐẶT VÀ CHẠY ỨNG DỤNG

### 1. Cấu hình CSDL (MySQL)

- Tạo database: `ChatLAN_DB`
- Nhập các bảng: `Users`, `PrivateMessages`, `GroupMessages`, `GroupMembers`, v.v.
- Chỉnh chuỗi kết nối trong `SQLConnect.cs`

### 2. Build & Run

- Mở solution `.sln` bằng Visual Studio
- Build server và client
- Mỗi máy client phải nằm trong cùng mạng LAN (Hiện tại mặc định sẽ dùng local 127.0.0.1)

---

## 📷 DEMO

![Screenshot 2025-06-02 205642](https://github.com/user-attachments/assets/4bfe448b-de89-4260-84d4-2b44679a6f3c)
![Screenshot 2025-06-02 205709](https://github.com/user-attachments/assets/780dc2ec-226c-477d-b726-a8f2cf3fd197)
![Screenshot 2025-06-02 205720](https://github.com/user-attachments/assets/69a535c2-288d-4c72-9c7a-d6e820c173b7)
![Screenshot 2025-06-02 205738](https://github.com/user-attachments/assets/97af112b-3e3f-4df2-91dd-9441fa526446)
![Screenshot 2025-06-02 205757](https://github.com/user-attachments/assets/f10a9678-1849-44ab-a542-c9938762f378)
![Screenshot 2025-06-02 205827](https://github.com/user-attachments/assets/df5a9519-0880-4b4b-b21e-08752a223913)
![Screenshot 2025-06-02 205620](https://github.com/user-attachments/assets/65428244-bc35-4a13-8a74-437ddebfedc3)

![Screenshot 2025-06-02 210310](https://github.com/user-attachments/assets/8365a378-f242-429c-861f-f0b18b2f570b)

---

## ⚙️ YÊU CẦU HỆ THỐNG

- Windows 10 trở lên
- .NET Framework 8+ 
- MySQL Server

### Ứng dụng vẫn chưa hoàn thiện hẳn
---

## 👨‍💻 TÁC GIẢ

**Xây dựng Ứng dụng Trò chuyện**    
      **Đào Huy Hoàng**
---
