using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCourse.Tests
{
    public static class WorldsDumbestFunctionTest
    {
        //Naming Convention - ClassNam_Method_Name_Expectedresult
        public static void WorldsDumbestFunction_returnPikachuIfZero_ReturnStringPikachu()
        {
            try
            {
                // Arrange
                int num = 0;

                //Act
                WorldsDumbestFunction WDF = new WorldsDumbestFunction();
                string result = WDF.returnPikachuIfZero(num);

                //Assert
                if (result == "Squirtle")
                {
                    Console.WriteLine("PASSED");
                }
                else
                {
                    Console.WriteLine("FAILED");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
