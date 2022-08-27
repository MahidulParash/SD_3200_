# SD_3200_
This is an E-learning website
In this project, our goal was to develop a website where people can register and enroll in their desired courses. In this website
- Students are able to register and login
- Students can enroll into different courses
- After enrollment, students get access to video lessons
- Instructors are able to create,edit and delete courses
- Instructors are also able to manage student database
- Through paid enrollment process, instructors are able to restrict their course contents

Here are the implemented features of our project-
* Login and Registration
Our proposed system had two types of users - instructors and students. We were able to successfully implement the login and registration functionalities of both type of users. We have ensured proper authorization by cross checking user credentials from both front-end and back-end. 

* Unique navigation bar for different user 
We have created three types of navigation bars for the users
-General layout for unregistered users
-Login layout for registered students
-Admin layout for registered instructors

* Resume Session
In our website, when a user logs out of his/her session, we have saved a cookie in the browser. By using that, users are able to resume the session when they log in again. 

* Student Dashboard
After logging in, students are directed to the dashboard. In the dashboard, students get the list of all their enrolled courses. 

* Course Page
Course page showcases all the available courses. Any unregistered user can browse through the course list. But in order to enroll into the courses, they need to login. A logged in user can enroll into the courses.

On the other hand, instructors get different type of access to the course list. They can edit or delete the courses. 

* Course Enrollment 
In the proposal, we were not sure about the payment process for the course enrollment. But in this system, we have implemented it. 
 
A logged in user can request enrollment into a course. For that student will have to pay the course price through mobile banking and provide the transaction id. Then the instructor will be provided with the list of enrollment requests. By matching the transaction id, instructor will approve access to the course. 

* Course Creation
In the proposal we mentioned that the instructors will be able to create courses. Here in the website, the instructor will be able to create new courses by providing course name, description and images. 

* Video Lessons
Each course containis a number of video lessons. Instructors will upload these lessons. We have used a third party website called Vimeo for this purpose. Since we are using the free version, we have some limitations. In the future versions, we’ll try to get the premium version for the extra perks. 

* Admin Dashboard
The admin dashboard will display some of the relevant statistics of the website including number of enrollments on that day, total number of students and courses. 

*Profile Edit
Both the students and instructors can edit their name and passwords.

* Feedback
The registered students are able to send their feedback through the ‘Contact Us’ page. The instructors are able to go through the feedback and its sender’s information from their dashboard. 


