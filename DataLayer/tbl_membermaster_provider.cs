using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public  class tbl_membermaster_provider // this class is use for the remove and changes of the student data //
    {
        public static void delete(int id)
        {
            using (sisEntities2 context = new sisEntities2())
            {
                student obj = context.students.First(x => x.Id == id);
                context.students.Remove(obj);
                context.SaveChanges();

            }
        }
        public static void EditUpdate(int id, String name, String email, String mno)
        {
            using (sisEntities2 context = new sisEntities2()) // this comment show the details of the student data //
            {

                student obj = context.students.First(x => x.Id == id);
                obj.stu_name = name;
                obj.stu_email =email;
                obj.stu_mno = mno;
                obj.stu_batch = obj.stu_batch;
                obj.stu_stream = obj.stu_stream;
                context.SaveChanges();

            }

        }
        public static void registernew(String uname, String upass)
        {

                       
            using (sisEntities2 context = new sisEntities2())
            {
            
                student_register obj = new student_register(); // this comment is use for the username and password for the student //
                obj.username = uname;
                obj.password = upass;


                context.student_register.Add(obj);
                
                context.SaveChanges();

            }
        }
        public static bool userlogin(String uname,String password)
        {
            using (sisEntities2 context = new sisEntities2()) // this comment is use for the register table of student //
            {

             
                student_register obj = (student_register)context.student_register.Where(x => x.username == uname).Where(x => x.password == password).FirstOrDefault();
                if (obj == null)
                {
                    return (false);
                }
                else
                {
                    return (true);
                }

            }

        }
        public static bool adminlogin(String uname, String password)
        {
            using (sisEntities2 context = new sisEntities2())
            {


                admin obj = (admin)context.admins.Where(x => x.username == uname).Where(x => x.password == password).FirstOrDefault();
                if (obj == null)
                {
                    return (false);
                }
                else
                {
                    return (true);
                }

            }

        }

        public static List<student> getallusers(String uname)
        {
            List<student> lst = null;
            using (sisEntities2 db = new sisEntities2()) // this comment is use for the return and also it show the taht where are you in table //
            {
                             
            lst = (from u in db.students select u).Where(x => x.stu_name == uname).ToList();


            }
            return (lst);
        }
        public static List<student> getallusers()
        {
            List<student> lst = null;
            using (sisEntities2 db = new sisEntities2())
            {

                lst = (from u in db.students select u).ToList();


            }
            return (lst);
        }
    }
}
