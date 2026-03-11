# InteractHub - Social Media Full-Stack Web Application

**TRƯỜNG ĐẠI HỌC SÀI GÒN**  
**KHOA CÔNG NGHỆ THÔNG TIN**

**Môn học:** C# and .NET Development  
**Học kỳ:** Spring 2026  
**Bài tập lớn:** InteractHub  
**Tổng điểm:** 10 điểm  
**Loại:** Dự án nhóm (4 người)  
**Thời hạn nộp:** 19/04/2026

TP. HỒ CHÍ MINH, NĂM 2026

## Mô tả dự án

InteractHub là một nền tảng mạng xã hội web full-stack, cho phép người dùng:

- Tạo tài khoản và xác thực an toàn (JWT + ASP.NET Identity)
- Đăng bài viết (text + ảnh)
- Chia sẻ story (tự động hết hạn sau 24h)
- Like, comment, báo cáo bài viết
- Gửi/nhận yêu cầu kết bạn
- Nhận thông báo thời gian thực (SignalR)
- Quản lý profile, theo dõi hashtag trending
- Tìm kiếm người dùng, infinite scroll feed, responsive design

**Mục tiêu học tập:**

- Xây dựng SPA responsive với React + TypeScript + Tailwind CSS
- Phát triển RESTful API sạch với ASP.NET Core + EF Core
- Áp dụng Repository + Service pattern, JWT Auth, Unit Testing
- Deploy lên Azure với CI/CD (GitHub Actions)

## Công nghệ sử dụng (Technology Stack)

### Frontend

- React 18+ + TypeScript (strict mode)
- Vite (build tool)
- Tailwind CSS v4 (zero-config với @tailwindcss/vite)
- State Management: React Context / Redux Toolkit
- Routing: React Router v6+
- Forms & Validation: React Hook Form
- HTTP Client: Axios (với interceptor cho JWT)
- Real-time: @microsoft/signalr (cho notifications)

### Backend

- ASP.NET Core 8.0+ Web API
- Entity Framework Core 8.0+ + SQL Server (Azure SQL)
- Authentication: JWT + ASP.NET Core Identity
- Architecture: Layered (Domain → Application → Infrastructure → API)
- API Documentation: Swagger/OpenAPI
- Real-time: SignalR
- File Storage: Azure Blob Storage (cho ảnh post/story)

### DevOps & Cloud

- **(Chưa làm)** CI/CD: GitHub Actions → Azure App Service + Static Web Apps
- Database: Azure SQL
- Storage: Azure Blob
- Deployment: Azure App Service (backend) + Azure Static Web App (frontend)

## Cấu trúc dự án

```

InteratHUB/
├── backend/ # Toàn bộ .NET backend
│ ├── InteractHub.API/ # Web API project
│ ├── InteractHub.Domain/ # Entities, enums, value objects
│ ├── InteractHub.Application/ # Interfaces, DTOs, Services
│ ├── InteractHub.Infrastructure/ # DbContext, Repositories, EF config
│ ├── InteractHub.Tests/ # xUnit unit tests
│ └── InteractHub.sln
├── frontend/ # React + Vite + TS
│ ├── src/
│ │ ├── components/
│ │ ├── pages/
│ │ ├── services/
│ │ ├── hooks/
│ │ ├── types/
│ │ ├── context/
│ │ ├── App.tsx
│ │ └── main.tsx
│ ├── tailwind.config.js (nếu dùng v3)
│ ├── vite.config.ts
│ └── package.json
├── .gitignore
└── README.md # File này

```

## Tiến độ hiện tại (tính đến 10/03/2026)

- **Setup hoàn tất**:
  - Backend: Solution layered (.NET 8), 9 entities + ApplicationUser (extend IdentityUser<Guid>), packages EF Core, Identity, JWT, Swagger, xUnit + Moq.
  - Frontend: React + TS + Vite, Tailwind CSS (v4 với @tailwindcss/vite hoặc v3 nếu downgrade), react-router-dom, axios, react-hook-form, @reduxjs/toolkit.
  - Git: Repo chung, branch develop, .gitignore chuẩn .NET + React.

- **Đã làm xong Tuần 1 (08/03 – 14/03)** (trừ phần Cloud của D):
  - A: Setup solution, entities, DbContext cơ bản (sẵn sàng migration).
  - B: Packages + xUnit project.
  - C: React Vite + Tailwind + folder structure + packages core.
  - D: Azure account + resource group (chưa deploy).

- **Tiếp theo** (Tuần 2): Implement Auth (JWT), API controllers đầu tiên (Auth, Posts), kết nối frontend với backend.

## Hướng dẫn chạy local

### Backend

1. Mở `backend/InteractHub.sln` bằng Visual Studio.
2. Cập nhật connection string trong `appsettings.json` (hoặc `appsettings.Development.json`):
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=InteractHubDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

````

3. Chạy migration (nếu chưa):
   ```
   dotnet ef migrations add InitialCreate --project InteractHub.Infrastructure --startup-project InteractHub.API
   dotnet ef database update --project InteractHub.Infrastructure --startup-project InteractHub.API
   ```
4. Chạy API: Set InteractHub.API làm startup project → F5.
   → Swagger tại: https://localhost:5001/swagger (hoặc port khác).

### Frontend

1. Vào thư mục `frontend/`:
   ```
   npm install
   npm run dev
   ```
   → Mở http://localhost:5173

### Kết nối Frontend ↔ Backend

- Sau khi backend chạy, cập nhật base URL trong `src/services/api.ts` (hoặc Axios instance):
  ```ts
  const api = axios.create({
    baseURL: "https://localhost:5001/api",
    // ... interceptor cho JWT
  });
  ```

## Quy ước nhóm & Công cụ

- **Git**: Branch `develop` chính, feature branches `feature/[tên-task]`. PR cần ít nhất 1 approve. A là merge gatekeeper.
- **Commit message**: `[Module][Người] Mô tả ngắn` ví dụ: `[Auth][A] Implement JwtService + claims`
- **Daily standup**: 15 phút sáng (Zalo/Meet): Hôm qua làm gì? Hôm nay kế hoạch? Block gì?
- **Khi stuck**: Debug 30 phút → post group chat + lỗi + đã thử gì.
- **API thay đổi**: Update Google Doc API contract + thông báo group.

## Checklist yêu cầu assignment (10 điểm - đánh dấu khi hoàn thành)

- [x] F1: ≥15 components + TS interfaces + responsive (screenshots 3 breakpoints)
- [ ] F2: State management + Axios interceptor + hooks (usePosts, useAuth, optimistic UI)
- [ ] F3: 4 forms (Register/Login/Post/Profile) + React Hook Form + validation
- [ ] F4: Protected routes + debounce search + infinite scroll + SignalR + lazy load
- [x] B1: 9 entities + DbContext + Fluent API + migrations + seed data + DB diagram
- [ ] B2: ≥6 controllers + ≥20 endpoints + DTOs + Swagger
- [ ] B3: Register/Login + JWT + [Authorize] + roles/claims
- [ ] B4: ≥5 services + DI + repository pattern + file upload
- [ ] T1: xUnit + ≥15 tests + Moq + coverage ≥60%
- [ ] D1: Azure live URL + GitHub Actions CI/CD + Blob Storage

## Tài liệu tham khảo

- Assignment PDF: [c sharp assignment.pdf]
- Lộ trình nhóm: [c sharp schedule.docx]
- Official Docs:
  - ASP.NET Core: https://learn.microsoft.com/aspnet/core
  - EF Core: https://learn.microsoft.com/ef/core
  - React + Vite: https://vitejs.dev
  - Tailwind CSS: https://tailwindcss.com
  - SignalR: https://learn.microsoft.com/aspnet/core/signalr

## Lưu ý nộp bài

- Nộp trước 02/04/2026 để có buffer fix bug.
- ZIP source code (không node_modules, bin/obj) + docs + screenshots + live URL.
- GitHub repo private/public + Azure URL + Postman collection (Swagger export).

**Nhóm 4 người** – Cùng cố gắng hoàn thành đúng hạn và đạt điểm cao nhé!
**Liên hệ group chat nếu cần hỗ trợ.**

Cập nhật lần cuối: 10/03/2026

````

Bạn copy nội dung trên vào file **README.md** (dùng VS Code hoặc Notepad), commit lên Git:

```bash
git add README.md
git commit -m "Add comprehensive README.md for team reference"
git push origin develop
```
