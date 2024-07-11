### Credit-Hour System: Graduation Project Overview

**Project Description:**

Credit-Hour System is a sophisticated web application developed using .NET Core, designed to streamline academic management processes for educational institutions. The system provides a robust API, adhering to SOLID principles and structured using a three-tier architecture, ensuring high maintainability, scalability, and performance. The application caters to both instructors and students, offering distinct modules for each user group to efficiently manage their academic activities.

**Key Features:**

1. **Instructor Module:**
   - **Get Instructor Timetable:** Instructors can view their scheduled classes and commitments for the semester, ensuring efficient time management.
   - **Post Grades to Students:** Instructors can submit grades for their students, maintaining academic records and facilitating performance tracking.
   - **Post Absence:** Instructors can mark student absences, providing an accurate attendance record for each class.
   - **Get Evaluation Sheet:** Instructors can access evaluation sheets, offering a comprehensive overview of student performance and feedback.

2. **Student Module:**
   - **Get Timetable:** Students can view their class schedules, ensuring they are aware of their commitments and can manage their time effectively.
   - **Enroll in a Course:** Students can enroll in courses, provided they have completed the prerequisite courses, supporting academic progression.
   - **Withdraw Course:** Students can withdraw from courses, offering flexibility in managing their course load.
   - **Show Results in Courses:** Students can view their grades and performance in enrolled courses, enabling them to track their academic progress.
   - **Show Finished and Unfinished Courses and Their Hours:** Students can see a detailed breakdown of completed and pending courses, along with their respective credit hours, aiding in academic planning.
   - **Enroll in Course if Grade is Unsatisfactory:** Students dissatisfied with their grades can re-enroll in courses, providing an opportunity for grade improvement.

**Architecture:**

- **SOLID Principles:**
  - The application strictly follows SOLID principles, ensuring a clean, maintainable, and extensible codebase. This approach enhances the quality of the code and facilitates future development and maintenance.

- **Three-Tier Architecture:**
  - The project is divided into three main layers:
    - **Presentation Layer:** Exposes APIs for user interactions and data retrieval, implemented using .NET Core.
    - **Business Logic Layer (BLL):** Contains business rules and logic, implemented with C# services and managers.
    - **Data Access Layer (DAL):** Manages data storage and retrieval, implemented using Entity Framework and repositories.

**Technology Stack:**

- **Backend:**
  - .NET Core for API development
  - C# for business logic implementation
  - Entity Framework for data access

- **Database:**
  - SQL Server for storing academic data and user information

**Development Tools:**

- Visual Studio for development and debugging
- Git for version control
- SQL Server Management Studio for database management

**How to Run:**

1. Clone the repository from GitHub.
2. Open the solution in Visual Studio.
3. Configure the database connection string in `appsettings.json`.
4. Run the Entity Framework migrations to set up the database.
5. Build and run the application.
**Swagger Screenshots:**

![image](https://github.com/elazazy424/Credit-Hour-System/assets/73352569/1f056f8c-cfd4-458d-b1ea-2db7b7544fe9)
![image](https://github.com/elazazy424/Credit-Hour-System/assets/73352569/b2b2949e-3851-463a-b8d0-833bd40d7911)
![image](https://github.com/elazazy424/Credit-Hour-System/assets/73352569/ba9e67c1-fb32-4236-9278-ea21a7e92a5d)

**Conclusion:**

Credit-Hour System exemplifies a robust academic management solution, offering essential functionalities for both instructors and students. By adhering to SOLID principles and utilizing a three-tier architecture, the application ensures high maintainability, scalability, and performance. It serves as an excellent foundation for further enhancements and can be extended to include additional features such as automated notifications, analytics, and reporting tools, further enriching the academic management experience.
