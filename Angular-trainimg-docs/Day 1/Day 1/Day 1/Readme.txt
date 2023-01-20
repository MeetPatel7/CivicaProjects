Lab setup 
How to execute Javascript file with node js
Web development Introduction
Javascript Variable, String, Array, Function and Object
ES6 - let, const, arrow function, class 
Project Discussion
Assignments
Pre-assessment

Client side 
------------

HTML - Hypertext markup language - .html - to display data in web browser
CSS - Cascading stylesheet - To design web pages 
    CSS Framework
        Bootstrap - version 5 - To create responsive websites 

Javascript 
    Javascript library 
        jQuery - Write less do more 
        React 
    Javascript Framework    
        Angular 
            Angular Material 

Server side 
------------

PHP 
Python
PERL 
Asp.net 
Java 
Nodejs (based on Javascript)

Database 
---------

Oracle 
Sql 
Mysql 
Postgresql 
Sqllite 

Nosql Database (json) Javascript object notation 
--------------------------------------------------

Mongodb 
Firebase 
Solr 

Fullstack developer
-------------------- 

Frontend + backend + database  

html, css, javascript, php, mysql 
html, css, javascript, java, sql 
html, css, javascript, MERN or MERN 

MEAN - Mongodb, Express, Angular and Nodejs 

MERN - Mongodb, Express, React and Nodejs 


To run javascript pages with nodejs, simply type 

node filename.js 
node 01.js 

1. Camera is on 
2. Pre-assessment 15 Objective Questions - https://forms.gle/MJACQqAvSmsd5x266
3. Postassessment
4. Project activities 
5. Assignments



Angular Component



Project - Communication Application 

1. Create below Components and UI ready

Welcome
Login 
LoginSuccessful
Register 
RegisterSuccessful
UsersManagement 
GroupChat 
DocsManagement
Logout 

2. All Form Validation using Reactive Form

Register, Login, EditUsers, SendChat, Edit Upload, Add upload ...

Empty field Validation
Email validation 
Password and Confirm password field validation 

3. When users register, insert data in to localstorage (users), When same user register again, then display error message users already exist

For example, insder array of object below inside users localstorage

[
    {
        id: 1,
        fullname: 'Anne Hunter',
        email: 'anne.hunter@gmail.com',
        password: 'anne123'
    }
]

4. On Login page, when user enter email and password and click on login, check weather user email and password exist inside localstorage or not.

if exist redirect to LoginSuccessful page else stay on the same page with proper error message.

When use login store loggedIn user information inside local storage

For example, loggedIn user detail below 

{
    fullname: 'Anne Hunter',
    email: 'anne.hunter@gmail.com',
}

For navigation use angular routing

Chat Management 

5. When use type message and click on send button, store chat information inside chats localstorage

chats 

[
    {
        date: '23-11-2022',
        fullname: 'Anne',
        message: 'Hi'
    }
]

6. On Chat page, display chat information from localstorage along with loggedIn username.

chats localstorage
loggedIn localstorage

7. When user click on refresh button refresh chat area, for example incase you are using div refresh div only 

Users Management

8. Display users from users localstorage.

9. When user click on edit, allow users to edit page, use reactive form approach.

10. When user click on delete, delete user from users localstorage.

Manage documents 

11. Display list of uploads from uploads localstorage
12. Allow users to edit upload using localstorage.
13. When user click on delete upload, delete from uploads localstorage.
14. When user click on logout remove loggedIn users from localstorage. 
15. Only logged in user can access internal pages else redirect to login page.
16. Implement Angular routing feature.

100 Marks 

1. Create proper folder structure, for images use images folder - 5 Marks 
2. User external CSS only - 5 Marks 
3. Format code - 5 Marks 
4. Proper comments - 5 Marks 
5. User meaningful name - 5 Marks 

loyaltyPrograms 
loyalty_programs 

don't do like this loyaltyprograms

6. Project completion on time - 25 Marks 
7. Individual Marks - 50 Marks 

Note:

User Angular Reactive Form 
Angular Routing 
Angular Guard
Component 
User service 
Use interface for data type 
Try to use angular lifecycle 
SCSS for styles 


