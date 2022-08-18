--Laura's Coding School Database

--(Part 1)
--The school has a number of Departments (one for each subject). Each Department has a number of Teachers, 
--one of which is the head of that Department. A Teacher may belong to several Departments.

--Departments have a number of Courses associated to them that each have their own course information (such as the 
--name of the course, what people expect to learn, any prerequisites prior to taking the course and what level NQF 
--level it is, etc). 

--Each Course may have several Classes that run. All classes will run on one day of the week either in the morning or
--afternoon and must have a Teacher.

--Classes will of course have Students and Students may attend several different classes.

--(Part 2)
--Ideally there should be procedures in place to help ensure that:

--- Teachers only teach Courses within there Department
--- Teachers can only be head of one Department
--- Teachers cannot teach 2 classes at the same time (2 classes on a Monday afternoon)
--- Likewise Students cannot attend 2 classes at the same time

--I should also easily be able to view:

--- All head of departments
--- Courses in each Department
--- Classes for each Course 

--- The number of Classes for each Teacher
--- The number of Students in each Class
--- The number of Students taught by a Department

--- Any Classes being taught by a given Teacher
--- Any Classes being attended by a given Student