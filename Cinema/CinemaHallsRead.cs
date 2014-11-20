using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cinema
{
    class CinemaHallsRead
    {
        List<string[,]> HallMass = new List<string[,]>();   //список залов с расположением мест
        List<string> path = new List<string>();             //пути к файлам с габаритами
        public void CinemaHallsAdd()
        {
            string[,] hall = new string[1, 1]; //начальные габариты каждого зала 1х1, а уже потом происходит переприсваивание
            HallMass.Add(hall);
        }

        public List<string> GetHallList()
        {
            string curentDir = Directory.GetCurrentDirectory();
            List<string> cinemaHall = new List<string>();
            
            foreach (var item in Directory.GetFiles(curentDir, "hall*"))    //ищем файлы начинающиеся на "hall"
            {
                cinemaHall.Add(Path.GetFileNameWithoutExtension(item)); //это значение уходит по ref
                path.Add(Path.GetFullPath(item));                       //это остаётся в методе
                CinemaHallsAdd();     //добавляем новый зал в массив залов используя конструктор класса
            }
            return cinemaHall;
        }

        public List<string[,]> ReadHallStructure()
        {
            int resolutionX = 0;    //параметр зала(Х) длина
            int resolutionY = 0;    //параметр зала(У) ширина
            int counter = 0;        //счётчик используется для определения resolutionY
            
            for (int cnt = 0; cnt < path.Count; cnt++)  //считываем все файлы с параметрами!(столько сколько есть в наличие)
            {
                using (FileStream fs = new FileStream(path[cnt], FileMode.Open, FileAccess.Read))   //FileStream
                {
                    using (StreamReader sr = new StreamReader(fs))                                  //StreamReader
                    {
                        for (int i = 0; i < 2; i++)     //два прохода т.к. за 1й назначаем размерность массивов 
                        {                               // а за 2й считываем в него все значения
                            //если размеры массива уже установлены
                            if (HallMass[cnt].GetLength(0) == resolutionX && HallMass[cnt].GetLength(1) == resolutionY) 
                            {
                                fs.Seek(0, SeekOrigin.Begin);
                                for (int j = 0; j < HallMass[cnt].GetLength(0); j++)            //вычитываем места в зале
                                {
                                    string tempString = sr.ReadLine();                  //вычитываем по рядам
                                    for (int k = 0; k < HallMass[cnt].GetLength(1); k++)
                                    {
                                        if (sr.EndOfStream) break;
                                        HallMass[cnt][j, k] = Convert.ToString(tempString[k]);   //познаково переносим в массив
                                    }
                                }
                            }
                            else        //если считанные габариты еще не переданы новому залу
                            {
                                fs.Seek(0, SeekOrigin.Begin);
                                do      //определение параметров считываемого зала
                                {
                                    resolutionX = sr.ReadLine().Count();    //длина
                                    counter++;
                                } while (!sr.EndOfStream);

                                resolutionY = counter;                      //ширина
                                counter = 0;
                                HallMass[cnt] = new string[resolutionX, resolutionY];  //рабочие габариты применены к залу!
                            }
                        }
                    }
                }
                resolutionX = 0;    //обнуляем перед следующим считыванием
                resolutionY = 0;
            }
            return HallMass;
        }
    }
}
