using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus
{
    class XuLy
    {
        static int maxNode = 42;
        //public int MaxNode
        //{
        //    get { return maxNode; }
        //    set { maxNode = value; }
        //}

        private int totalTime;
        private int tramHienTai = 0;
        private int tgMoiTuyen = 0;
        private int busHienTai = 0;
        private int tramTiepTheo = 0;
        private bool flags = true;
        private int soSVLenXe = 0;
        private int tgQuaTram = 0;
        public int TotalTime
        {
            get { return totalTime; }
            set { totalTime = value; }
        }

        List<Bus> bus = new List<Bus>();
        List<Stations> station = new List<Stations>();
        Distance[,] distance = new Distance[maxNode, maxNode];
        Dictionary<Bus, List<int>> trace = new Dictionary<Bus, List<int>>();
        List<string> loTrinh = new List<string>();
        string fileBus = "buses.txt", fileStation = "station.txt", fileDistance = "distance.txt";
        string DuongDan = @"D:\IDE\CSharp\SchoolBus\SchoolBus\data\";
        public void ReadData()
        {
            // read data from file Buses.txt
            string[] kq = File.ReadAllLines(DuongDan + fileBus);
            foreach (var s in kq)
            {
                Bus t = new Bus();
                string[] pt = s.Split('\t');
                t.Id = int.Parse(pt[0]);
                t.Seat = int.Parse(pt[1]);
                bus.Add(t);
            }
            //foreach (Bus b in bus)
            //{
            //    Console.WriteLine(b.Id + " " + b.Seat);
            //}
            Array.Clear(kq, 0, kq.Length);

            // read data from station.txt
            kq = File.ReadAllLines(DuongDan + fileStation);
            foreach (var s in kq)
            {
                Stations t = new Stations();
                string[] pt = s.Split('\t');
                t.Id = int.Parse(pt[0]);
                t.SoSV = int.Parse(pt[3]);
                t.Status = false;
                station.Add(t);
            }
            Array.Clear(kq, 0, kq.Length);

            // read data from distance.txt

            kq = File.ReadAllLines(DuongDan + fileDistance);

            int row = 0, col = 0;
            foreach (var s in kq)
            {
                Distance dis = new Distance();
                string[] pt = s.Split('\t');
                dis.KhoanCach = int.Parse(pt[0]);
                dis.Time = int.Parse(pt[1]);
                if (row < maxNode)
                {
                    if (col < maxNode)
                    {
                        distance[row, col] = dis;
                        col++;
                    }
                    else
                    {
                        row++;
                        col = 0;
                        distance[row, col] = dis;
                        col++;
                    }
                }
            }
            Console.WriteLine("Read all file successful");

            //for (int i = 0; i < maxNode; i++)
            //{
            //    for (int j = 0; j < maxNode; j++)
            //        Console.WriteLine(distance[i, j].KhoanCach + " " + distance[i, j].Time);
            //    Console.WriteLine();
            //}
        }


        private void quicksort(List<Distance> t, int left, int right)
        {
            int i = left, j = right;
            Distance tmp;
            int pivot = t[(left + right) / 2].KhoanCach;

            /* partition */
            while (i <= j)
            {
                while (t[i].KhoanCach < pivot)
                    i++;
                while (t[j].KhoanCach > pivot)
                    j--;
                if (i <= j)
                {
                    tmp = t[i];
                    t[i] = t[j];
                    t[j] = tmp;
                    i++;
                    j--;
                }
            };

            /* recursion */
            if (left < j)
                quicksort(t, left, j);
            if (i < right)
                quicksort(t, i, right);
        }

        public void sortNearNode(List<Distance> dis)
        {
            quicksort(dis, 0, dis.Count - 1);
        }
        // lấy trạm xa nhất
        public int getLongNode()
        {
            int range = 0;
            int node = -1;
            for (int i = 1; i < maxNode; i++)
            {
                if (range <= distance[0, i].KhoanCach && station[i].Status == false && i!= tramHienTai)
                {
                    range = distance[0, i].KhoanCach;
                    node = i;
                }
            }
            return node;
        }
        // lấy tất cả các trạm kề với trạm đang xét
        public List<int> getAllNearNode()
        {
            List<int> t = new List<int>();
            // không tính từ trạm đó về trường distance[node, 0]
            for (int i = 1; i < maxNode; i++)
            {
                if (station[i].Status == false && i != tramHienTai)
                {
                    t.Add(i);
                }
            }
            return t;
        }

        // lấy trạm gần với trạm đang xét nhất
        public int getNearNode(List<int> allNode)
        {
            int node = -1;
            if (allNode.Count != 0)
            {
                int range = distance[tramHienTai, allNode[0]].KhoanCach;

                for (int i = 0; i < allNode.Count; i++)
                {
                    if (range >= distance[tramHienTai, allNode[i]].KhoanCach && station[allNode[i]].Status == false && allNode[i] != tramHienTai)
                    {
                        range = distance[tramHienTai, allNode[i]].KhoanCach;
                        node = allNode[i];
                    }
                }
                return node;
            }
            else return node;
           
        }
        public int calcTotalSV()
        {
            int sv = 0;
            foreach (var i in station)
                sv += i.SoSV;
            return sv;
        }
        // xem kết quả sau khi tính đường đi
        public void show(Dictionary<Bus, List<int>> trace)
        {
            Console.WriteLine("Tong so tuyen: " + trace.Count);
            foreach (var p in trace)
            {
                Console.Write(p.Key.Id + ": ");
                foreach (var i in p.Value)
                {
                    Console.Write(i + " -> ");
                }
                Console.WriteLine();

            }
        }



        // hàn thực thi tính đường đi
        public void run2()
        {
            while (getLongNode() != -1)
            {
                tramHienTai = getLongNode();
                tgMoiTuyen = TotalTime;

                string temp = bus[busHienTai].Id.ToString() + " : ";
           
          
                while (flags == true && isFullSeat() == false)
                {
                    tramTiepTheo = tramKeTiep();
                    if (tramTiepTheo != -1 && isQuaTramKe() == true)
                    {
                        temp += tramHienTai.ToString();
                        quaTram();
                        temp += " [" + soSVLenXe.ToString() + " ... " + tgQuaTram.ToString() + "] --> ";
                    }
                    else
                    {
                        temp += tramHienTai.ToString();
                        veTruong();
                        temp += " [" + soSVLenXe.ToString() + " ... " + tgQuaTram.ToString() + "] --> 0";
                        flags = false;
                        break;
                    }
                }
         
                loTrinh.Add(temp);
                busHienTai++;
                flags = true;
            }
            display(loTrinh);
        }

        public void display(List<string> lt)
        {
            foreach (var t in lt)
                Console.WriteLine(t +"\n");
        }

        // set true = trạm đó không thể đi qua nữa
        public void setTrueStation(int tramHienTai)
        {
            // status = true tuc la tram do se khong di qua nua
            station[tramHienTai].Status = true;
        }

        // hàm đón sv ở mỗi trạm nó đi qua
        public void donSV(int SLSV)
        {
            if (SLSV <= bus[busHienTai].Seat)
            {
                bus[busHienTai].Seat -= SLSV;
                soSVLenXe = SLSV;
                setTrueStation(tramHienTai);
            }
            else
            {
                station[tramHienTai].SoSV -= bus[busHienTai].Seat;
                soSVLenXe = bus[busHienTai].Seat;
                bus[busHienTai].Seat = 0;
            }
        }
        // hàm xử lí khi được phép đi qua trạm kế tiếp
        public void quaTram()
        {
            tgMoiTuyen -= distance[tramHienTai, tramTiepTheo].Time;
            tgQuaTram = distance[tramHienTai, tramTiepTheo].Time;
            donSV(station[tramHienTai].SoSV);

            tramHienTai = tramTiepTheo;
            tramTiepTheo = tramKeTiep();
        }


        // tính thời gian từ trạm đang xét -> trạm kế -> về trường
        int timeToSchool()
        {
            return distance[tramHienTai, tramTiepTheo].Time + distance[tramTiepTheo, 0].Time;
        }
        // xử lí khi không qua được trạm kế
        public void veTruong()
        {
            tgMoiTuyen -= distance[tramHienTai, 0].Time;
            tgQuaTram = distance[tramHienTai, 0].Time;
            donSV(station[tramHienTai].SoSV);
        }
        // số ghế trên xe bus hiện tại đã đầy
        public bool isFullSeat()
        {
            //con ghe = false, het ghe = true
            if (bus[busHienTai].Seat == 0) return true;
            else return false;
        }

        // tìm trạm kế tiếp gần nhất cảu trạm đang xét
        public int tramKeTiep()
        {
            List<int> cacTramCoTheDen = getAllNearNode();
            if (cacTramCoTheDen.Count != 0)
            {
                int tramGanNhat = getNearNode(cacTramCoTheDen);
                return tramGanNhat;
            }
            else
                return -1;
    
        }
        // kiểm tra xem có qua trạm kế tiếp được hay không
        public bool isQuaTramKe()
        {
            //return -1 if not exists
            int tramGanNhat = tramKeTiep();
            // test lay khoan cach gan tram dang xet nhat

            if (tramGanNhat == -1) return false;

            if (timeToSchool() > tgMoiTuyen || station[tramHienTai].SoSV >= bus[busHienTai].Seat)
            {
                return false;
            }
            else
                return true;

        }
    }
}
