# Hệ Thống Quản Lý Ký Túc Xá

## Giới thiệu
Hệ thống Quản Lý Ký Túc Xá là một ứng dụng Windows Forms được phát triển bằng C# và SQL Server, giúp tự động hóa và quản lý hiệu quả các hoạt động của ký túc xá. Hệ thống cung cấp các công cụ quản lý toàn diện cho ban quản lý ký túc xá, nhân viên và sinh viên.

## Tính năng chính

### 1. Quản lý Sinh viên
- Thêm, sửa, xóa thông tin sinh viên
- Quản lý thông tin cá nhân (họ tên, ngày sinh, giới tính, email, địa chỉ)
- Theo dõi việc phân phòng
- Quản lý chính sách ưu tiên

### 2. Quản lý Phòng
- Phân chia và quản lý khu phòng
- Quản lý các loại phòng
- Theo dõi tình trạng phòng (trống/đã có người ở)
- Quản lý giá phòng

### 3. Quản lý Hợp đồng
- Tạo và quản lý hợp đồng ký túc xá
- Theo dõi thời hạn hợp đồng
- Quản lý gia hạn hợp đồng

### 4. Quản lý Hóa đơn
- Tạo và quản lý hóa đơn thanh toán
- Theo dõi các khoản phí phát sinh
- Quản lý lịch sử thanh toán

### 5. Quản lý Nhân viên
- Quản lý thông tin nhân viên
- Phân quyền người dùng
- Theo dõi công việc của nhân viên
### 6. Quản lý Khu
- Thêm khu   
- Sửa thông tin khu
### 6. Hệ thống Đăng nhập và Phân quyền
- Xác thực người dùng
- Phân quyền theo vai trò (sinh viên, nhân viên, quản lý)
- Bảo mật thông tin

## Cài đặt

1. Clone repository:
```bash
git clone https://github.com/duy-debug/dormitory_management_system.git
```

2. Cài đặt SQL Server và tạo database:
- Tạo database mới tên "QLKTX"
- Restore file backup database (nếu có) hoặc chạy script tạo database

3. Cấu hình connection string:
- Mở file `DatabaseHelper.cs`
- Cập nhật connection string phù hợp với cấu hình SQL Server của bạn

4. Build và chạy project:
- Mở solution trong Visual Studio 2022
- Build solution
- Chạy ứng dụng

## Cấu trúc project

```
QuanLyKyTucXa/
├── UI/                    # Giao diện người dùng
│   ├── Forms/            # Các form Windows Forms
│   └── Controls/         # Custom controls
├── Models/               # Các model dữ liệu
├── Db/                   # Xử lý database
├── Resources/            # Tài nguyên (hình ảnh, icons)
└── Properties/           # Cấu hình project
```

## Công nghệ sử dụng

- C# (.NET Framework)
- Windows Forms
- SQL Server
- Entity Framework
- ADO.NET

## Đóng góp

Mọi đóng góp đều được hoan nghênh! Vui lòng tạo issue hoặc pull request để đóng góp.

## Liên hệ

Nếu bạn có bất kỳ câu hỏi hoặc góp ý nào, vui lòng tạo issue trong repository.

## Tác giả

-Trần Mai Ngọc Duy (Leader) <br>
-Trần Minh Hoàng<br>
-Nguyễn Lê Thùy Linh<br>
-Ngô Văn Lực<br>

## Lời cảm ơn

Cảm ơn tất cả những người đã đóng góp vào project này. 
