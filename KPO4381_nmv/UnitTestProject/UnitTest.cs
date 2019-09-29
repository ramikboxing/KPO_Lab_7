using System;
using System.IO;
using System.Runtime.InteropServices;
using Kpo4381_nmv.Lib;
using Kpo4381_nmv.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace UnitTestProject
namespace Kpo4381_nmv
{
    [TestClass]
    public class UnitTest
    {
        private CarNewLoad_lab4 newLoader;
             
        public UnitTest()
        {
            newLoader = new CarNewLoad_lab4("Lab4Cars.txt");
        }
        //Test 1
        /*Проверка имени файла для загрузки*/
        [TestMethod]
        public void TestFileName()
        {
            try
            {
                var target = newLoader.getFileName;
                Assert.AreEqual("Lab4Cars.txt", target);
                LogUtility.Error("Тест 1 - Имя файла совпало ");
            }
            catch (Exception ex)
            {
                //LogUtility.Error("Тест 1  "+ ex);
               // Assert.IsTrue(false);
                throw new MyException("Тест 1 не пройден"); // Собственное исключение              
            }
        }
        //Тест 2
        /*Проверка марки первой машины в получаемом списке*/
        [TestMethod]
        public void TestExecuteMethodCarModel()
        {
            try
            {
                newLoader.Execute();
                var targetCarModel = newLoader.carsList[0].Mark;
                Assert.AreEqual("Mersedes", targetCarModel);
                LogUtility.Error("Тест 2 - Первая машина в списке -" + targetCarModel);
            }catch (Exception ex)
            {
                LogUtility.Error("Тест 2  " + ex);
                Assert.IsTrue(false);
            }
        }
        //Тест3
        /*Проверка на возврат не путого списка*/
        [TestMethod]
        public void CheckListNotNull_Class()
        {
            try
            {
                LoadCarListTest list = new LoadCarListTest();
                list.Execute(); //Вывзвать метот создающий и заполняющий список
                Assert.IsNotNull(list.carsList); //Если срисок есть то ОК
                LogUtility.Error("Тест 3 -Возвращен не пустой список");
            }
            catch (Exception ex)
            {
                LogUtility.Error("Тест 3  " + ex);
                Assert.IsTrue(false);
            }
        }
        //Тест 4
        /*Проверка пустой список из класса или нет*/
        [TestMethod]
        public void ChekListNotNull_File()
        {
            try
            {
                ICarFactory loader = new CarTestFactory(); // обращение к объектам через интер-с
                ICarsListLoader Loader = loader.CreateCarListLoader();
                Loader.Execute();// Заполнение списка
                Assert.IsNotNull(Loader.carsList);// Проверка списка на пустату 
                LogUtility.Error("Тест 4 -Возвращен не пустой список");
            }
            catch (Exception ex)
            {
                LogUtility.Error("Тест 4  " + ex);
                Assert.IsTrue(false);
            }
        }
        //Тест 5
        /**/
        [TestMethod]
        public void ChekListWithStatusSuccess_TestFileLoad()
        {   
            ICarFactory loader = new CarSplitFileFactory(); // обращение к объекту через интерфейс
            ICarsListLoader Loader = loader.CreateCarListLoader();
            /*Список удачно читается когда в классе CarSplitFileFactory явно передано имя файла
            для чтения, при передачи имени файла через AppGlobalSettin возникает исключения
            "Файл не найден" т.к. имя файла прочитываеться из App.config в переменную _dataFileName*/
            Loader.Execute();
            /*Если файл найден статус Succes иначе ReadingError*/
            if (Loader.status == LoadStatus.Succes)
            {
                LogUtility.Error("Тест 5 -Статус чтения -Удачное чтение");
                Assert.IsTrue(true);           
            }
            else
            {
                LogUtility.Error("Тест 5 -Статус чтения -Неудачное чтение");
                Assert.IsTrue(false);
            }
        }
    }
}

