# DesktopPsychologist_WF

## ��������

��� �������� ������, ��������� �� ���� ����������:
1. API_Psychologist - �������� �����. ���������� ��� ��������� ���������. ������ ������������� RESTful API ��� ���������� ������� ������������� � �������, ��������� ����������� ���� ���������� .NET 8 � MySQL.
2. DesktopPsychologist_WF - ���������� �����. ���������� Windows Forms, ������������� ��� �������������� ���������� �� ������� ��������� ����� ������� ���������� ���������. ���������� ���������� ����������� ���������� .NET � �������� ���������� � �������� API.

## ����������� ��������������

API_Psychologist
* ���������: .NET 8.0
* ORM: Entity Framework Core 8.0.3
* ������������� ������������ Swagger/OpenAPI: Swashbuckle.AspNetCore 6.5.0
* ���� ������: MySQL

DesktopPsychologist_WF
* ���������: .NET Framework 4.8
* �����������: Dependency Injection � �������������� Microsoft.Extensions.DependencyInjection
* ORM: Entity Framework 6
* ���������: Windows Forms

## ��������� � ������

### ��������������� ����������

����� �������� ������� ���������, ��� �� ����� ���������� �����������:
1. .NET 8.0 SDK
2. MySQL Server (������ 8.0 ��� ����)
3. IDE ��� �������� ���� (������������� Visual Studio 2022)
4. .NET Framework 4.8

### ������ � ��������� ����������

API_Psychologist
1. ���������� �����������: `git clone [https://github.com/Yaloznicky/API_Psychologist.git]`
2. �������� ������� � Visual Studio
3. ������������ NuGet ������
4. ��������� ���� ������ (���� ����������):
    
    4.1. �������� ������ ����������� � ����� appsettings.json:
    ```
        "ConnectionStrings": {
            "Default": "Server=localhost;User=root;Password=your_password;Port=port_number_;Database=dbpsychologist"
        },
    ```
        �������� your_password �� ������ ������ ������������ MySQL.
        �������� port_number �� ����� ����� ������ ������������ MySQL.
    4.2. ����������� �������� `dotnet ef database update`

DesktopPsychologist_WF
1. ���������� ����������� `git clone [https://github.com/Yaloznicky/DesktopPsychologist_WF.git]`
2. �������� ������� � Visual Studio
3. ������������ NuGet ������
4. �������� ������� (Ctrl+Shift+B)

### ������ � �������������

1. ��������� ���������� API_Psychologist: `dotnet run` ��� (F5)
2. ��������� ���������� DesktopPsychologist_WF (F5)

> **DesktopPsychologist_WF**\
> ��� ������� � ����������������� ���������� ����� ��������������� ������� ������� ��������������: ����� - Admin, ������ - 123.\
> � ������ ������� �� ������������ ��������� ������� �� ���������� ��������, ������������� ���� � ������� � ������ ��������, ���� � ����. ��������.\
> ��� �������� ������� ���������� ������������ ����������� ��������� �������.

## ������������ API

����� ������� ���������� API_Psychologist ������������ API �������� ����� Swagger UI: http://localhost:5180/swagger

## ����������

������������� ���������� � �������� ��������� �� ���������.

## ���������

* ���������� ��������� ����������