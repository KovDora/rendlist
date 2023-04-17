using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendezett_lista
{

    /*Feladatok:
     * 13
     * 14
     * 15
     * */
    class RendezettLista
    {
        private List<int> tartalom;

        //1. Készíts egy privát Helye metódust, egy tetszőleges elem esetén megmondja, hogy az hol van a listában, amennyiben benne van a listában, vagy megválaszolja azt, hogy milyen indexe lenne, ha bekerülne a listába!
        private int Helye(int Elem)
        {
            int eleje = 0;
            int vége = tartalom.Count - 1;
            int közepe;

            do
            {
                közepe = (eleje + vége) / 2;
                if (tartalom[közepe] < Elem)
                {
                    vége = eleje + 1;
                }
                else if (tartalom[közepe] > Elem)
                {
                    vége = közepe - 1;
                }
                else
                {
                    return közepe;
                }
            } while (eleje <= vége);
            return eleje;
        }

        //2. Készíts egy Add metódust, amely egy elemet elhelyez a listában, amennyiben az még nem volt benne. Ha már volt ilyen elem a listában, akkor ne csináljon semmit.
        public void Add(int Elem)
        {
            tartalom.Insert(Helye(Elem), Elem);
        }

        //4. Készíts egy IndexOf metódust, ami megmondja egy elem indexét, ha benne van a rendezett halmazban, és -1-et ad, ha nincsen benne!
        public int indexOf(int Elem)
        {
            int helye = Helye(Elem);

            if (helye == tartalom.Count)
            {
                return -1;
            }
            else if (tartalom[helye] == Elem)
            {
                return helye;
            }
            else
            {
                return -1;
            }
        }

        //3.Készíts egy Contains metódust, ami megmondja, hogy egy elem szerepel-e a listában vagy sem! tehát pl a fenti halmaznál : rh.Contains(6) legyen igaz, de pl. rh.Contains(7) legyen hamis.
        public bool Contains(int Elem)
        {

            int keresve = indexOf(Elem);
            if (keresve == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //5. Készíts Remove method-ot metódust, ami azt csinálja, hogy egy megadott elemet kiszed a listából. Pl. ha a halmaz rh = [ 6 8 9 13 ], akkor rh.Remove(9) után legyen ez: [6 8 13]. Ha nincs benne olyan elem, amit ki lehetne venni, akkor az ilyen parancsnak nem kell semmilyen követkeménye legyen.
        public void Remove(int Elem)
        {
            int helye = indexOf(Elem);
            if (helye != -1)
            {
                tartalom.RemoveAt(helye);
            }
        }

        //6. Készíts egy konstruktort, ami egy megadott lista alapján létrehoz egy olyan rendezett halmazt, amelynek pontosan a listában megadott elemek az elemei (csak sorrendben!).
        public RendezettLista(List<int> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                int minindex = i;
                for (int j = i; j < lista.Count; i++)
                {
                    if (lista[j] > lista[minindex])
                    {
                        minindex = j;
                    }
                }
                int temp = lista[i];
                lista[i] = lista[minindex];
                lista[minindex] = temp;

            }


            tartalom = lista;

        }


        //7. Készíts egy IntervallumMetszet(int a,int b) metódust, amely egy olyan rendezett halmazt ad vissza, amely a rendezett halmaz pontosan azon elemeit tartalmazza, amelyek nem kisebbek, mint a, és nem nagyobbak, mint b! Tehát pl. a fenti példában rh.IntervallumMetszet(8,10) eredménye egy ilyen rendezett halmaz: [8, 9]
        public RendezettLista IntervallumMetszet(int a, int b)
        {
            List<int> lista = new List<int>();
            int vége = Helye(b);
            if (tartalom[vége] > b)
            {
                vége--;
            }
            for (int i = Helye(a); i < vége; i++)
            {
                lista.Add(tartalom[i]);
            }

            RendezettLista rendezettlista = new RendezettLista(lista);
            return rendezettlista;
        }

        //8. Írj Max() metódust, ami a legnagyobb elemet adja vissza!
        public int Max()
        {
            return tartalom[tartalom.Count - 1];
        }

        //9. Írj Min() metódust, ami a legkisebb elemet adja vissza!
        public int Min()
        {
            return tartalom[0];
        }

        //11. Írj Nagy(int n) metódust, ami az n-edik legnagyobb elemet adja vissza
        public int Nagy(int n)
        {
            return tartalom[tartalom.Count - n];
        }

        //12. Írj Kicsi(n) metódust, ami az n-edik legkisebb elemet adja vissza!
        public int Kicsi(int n)
        {
            return tartalom[n - 1];
        }

        //10. Írj metódust, ami megadja az adatok terjedelmét! Azaz a legnagyobb és legkisebb elem értékbeli távolságát.
        public int Count()
        {
            return this.tartalom.Count;
        }

        //16. Két rendezett halmaz uniója/összefuttatása az elemeiket tartalmazó új rendezett halmaz, amelyben pontosan akkor szerepel elem, ha valamelyik rendezett halmazban szerepelt. Ha műveleti jelet használsz, használj + jelet!
        public RendezettLista Unió(RendezettLista másik)
        {
            List<int> lista = new List<int>();

            int i = 0;
            int j = 0;

            while (i < this.tartalom.Count && j < másik.tartalom.Count)
            {
                if (this.tartalom[i] < másik.tartalom[j])
                {
                    lista.Add(this.tartalom[i]);
                    i++;
                }
                else if (this.tartalom[i] > másik.tartalom[j])
                {
                    lista.Add(tartalom[j]);
                    j++;
                }
                else
                {
                    lista.Add(tartalom[i]);
                    lista.Add(tartalom[j]);
                    i++;
                    j++;
                }

            }

            while (i < this.tartalom.Count)
            {
                lista.Add(this.tartalom[i]);
                i++;
            }

            while (j > másik.tartalom.Count)
            {
                lista.Add(másik.tartalom[j]);
                j++;
            }

            RendezettLista rendezettlista = new RendezettLista(lista);
            return rendezettlista;
        }

        //17.Két rendezett halmaz metszete a közös elemeiket tartalmazó új rendezett halmaz. Ha műveleti jelet használsz, használj * jelet!
        public RendezettLista Metszet(RendezettLista másik)
        {
            List<int> lista = new List<int>();
            int i = 0;
            int j = 0;

            while (i < this.tartalom.Count && j < másik.tartalom.Count)
            {
                if (this.tartalom[i] < másik.tartalom[j])
                {
                    i++;
                }
                else if (this.tartalom[i] > másik.tartalom[j])
                {
                    j++;
                }
                else
                {
                    lista.Add(tartalom[i]);
                    i++;
                    j++;
                }

            }

            RendezettLista rendezettlista = new RendezettLista(lista);
            return rendezettlista;
        }

        //18. Egy A és B rendezett halmaz különbsége az A lista azon elemeit tartalmazó új rendezett halmaz, amely nem tartalmazza B elemeit. Ha műveleti jelet használsz, használj - jelet!
        public RendezettLista Különbség(RendezettLista másik)
        {
            List<int> lista = new List<int>();

            int i = 0;
            int j = 0;
            while (i < this.tartalom.Count && j < másik.tartalom.Count)
            {
                if (this.tartalom[i] < másik.tartalom[j])
                {
                    lista.Add(this.tartalom[i]);
                    i++;
                }
                else if (this.tartalom[i] > másik.tartalom[j])
                {
                    j++;
                }
                else
                {
                    i++;
                    j++;
                }

            }

            while (i < this.tartalom.Count)
            {
                lista.Add(this.tartalom[i]);
                i++;
            }

            RendezettLista rendezettlista = new RendezettLista(lista);
            return rendezettlista;
        }

        //13. Add meg az elemek mediánját visszaadó metódust! (egy adathalmaz mediánja az az elem, amely sorba rakva az elemeket a középső, illetve páros sok elem esetén a középső kettő átlaga!)
        public RendezettLista Medián(RendezettLista másik)
        {
            List<int> lista = new List<int>();

            int i = 0;
            int j = 0;

            RendezettLista rendezettlista = new RendezettLista(lista);
            return rendezettlista;
        }

    }
}

