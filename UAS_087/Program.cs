using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_087
{
    class Node
    {
        public int jenisbarang;
        public string nama;
        public Node next;

    }

    class List
    {
        Node START;
        public List()
        {
            START = null;
        }

        public void addNode()/*method untuk menambahkan sebuah Node kedalam List*/
        {
            int jenisbarang;
            string nm;
            Console.WriteLine("\nMasukkan Jenis barang: ");
            jenisbarang = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan id barang, nama barang, dan harga barang: ");
            nm = Console.ReadLine();
            Node nodeBaru = new Node();
            nodeBaru.jenisbarang = jenisbarang;
            nodeBaru.nama = nm;

            if (START == null || jenisbarang <= START.jenisbarang) /*Node ditambahkan sebagai node*/
            {
                if ((START != null) && (jenisbarang == START.jenisbarang))
                {
                    Console.WriteLine("\n\n");
                    return;
                }
                nodeBaru.next = START;
                START = nodeBaru;
                return;
            }

            /*menemukan lokasi node baru didalam list*/

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (jenisbarang >= current.jenisbarang))
            {
                if (jenisbarang == current.jenisbarang)
                {
                    Console.WriteLine("\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            /*Node baru akan ditempatkan diantara previous dan current*/

            nodeBaru.next = current;
            previous.next = nodeBaru;
        }
        /*Method untuk menghapus node tertentu didalam list*/
        public bool delNode(int jenisbarang)
        {
            Node previous, current;
            previous = current = null;
            /*Check apakah node yang dimaksud ada didalam List atau tidak*/
            if (Search(jenisbarang, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        /*Method untuk menge-check apakah node yang dimaksud ada didalam List atau tidak*/
        public bool Search(int jenisbarang, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current == null) && (jenisbarang != current.jenisbarang))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);
        }
        /*Method traverse/mengunjungi dan membaca isi list*/    
        public void traverse()
        {
            if (ListEmpty())
                Console.WriteLine("\nList kosong: \n");
            else
            {
                Console.WriteLine("\nData didalam list adalah: \n");
                Console.WriteLine("Jenis barang | Id barang | Nama barang | Harga barang |");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.jenisbarang + "  " + currentNode.nama + "\n");
                Console.WriteLine();

            }
        }

        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        class Program
        {
            static void Main(string[] args)
            {
                List obj = new List();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("===================================================");
                        Console.WriteLine("===========Toko Elektronik Semoga Tuntas===========");
                        Console.WriteLine("===================================================");
                        Console.WriteLine("");
                        Console.WriteLine("                         MENU                      ");
                        Console.WriteLine("");
                        Console.WriteLine("1. Menambah data kedalam List");
                        Console.WriteLine("2. Melihat semua data didalam List");
                        Console.WriteLine("3. Mencari sebuah data didalam List");
                        Console.WriteLine("4. Exit");
                        Console.WriteLine("\nMasukkan pilihan anda (1-4): ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.addNode();
                                }
                                break;
                            case '2':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '3':
                                {
                                    if (obj.ListEmpty() == true)
                                    {
                                        Console.WriteLine("\nList kosong !");
                                        break;
                                    }
                                    Node previous, current;
                                    previous = current = null;
                                    Console.Write("\nMasukkan jneis barang yang akan dicari: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref previous, ref current) == false)
                                        Console.WriteLine("\nData tidak ditemukan.");
                                    else
                                    {
                                        Console.WriteLine("\nData ketemu");
                                        Console.WriteLine("\nJenis barang: " + current.jenisbarang);
                                        Console.WriteLine("\nId barang, Nama barang, Harga barang: " + current.nama);
                                    }
                                }
                                break;
                            case '4':
                                return;
                            default:
                                {
                                    Console.WriteLine("\nPilihan tidak valid");
                                    break;
                                }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n");
                    }
                }
            }
        }
    }
}


// 2. Menggunakan singly linked list. Karena program yang diminta berupa list dari sebuah barang toko elektronik, yang mana single linked list lebih cocok,
//    dibandingkan double linked list. Double linked list bisa mengurutkan dari yang terbesar maupun yang terkecil, sedangkan pada kasus ini hal tersebut tidak dibutuhkan.
// 3. REAR dan FRONT
// 4. a. memiliki 4 kedalaman
//    b. menggunakan metode Inorder
//       15,20,25,31,32,35,30,48,50,66,67,69,94,98,99,65,70,90
