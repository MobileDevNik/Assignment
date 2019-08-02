# Assignment

1) Add Department and employees
URL - https://localhost:44361/api/departments
Method - POST
Basic Auth - username=admin password=pass
body - [
    {
        
        "departmentName": "English",
        "employees": [
            {
                "employeeName": "Nil"
            },{
                "employeeName": "Nik"
            }
        ]
    }
]

2) get all departments without employees
URL - https://localhost:44361/api/departments
Method - GET

3) get department by id (no employee records)
URL - https://localhost:44361/api/departments/1
Method - GET

4) update Department
URL - https://localhost:44361/api/departments/1
Method - PUT
Basic Auth - username=admin password=pass
body -
    {
        "departmentName": "Maths"
    }

5) delete Department
URL - https://localhost:44361/api/departments/1
Method - DELETE
Basic Auth - username=admin password=pass

6)Get all employees
URL - https://localhost:44361/api/employees
Method - GET

7)Get Employee by Id
URL - https://localhost:44361/api/employees/1
Method - GET

8)update Employee
URL - https://localhost:44361/api/employees/1
Method - PUT
Basic Auth - username=admin password=pass
body -
    {
        "employeeName": "Nikhil"
    }

9)Delete Employee
URL - https://localhost:44361/api/employees/1
Method - Delete
Basic Auth - username=admin password=pass

