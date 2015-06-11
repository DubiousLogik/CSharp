using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lists
{
    [TestClass]
    public class SinglyLinkedListTests
    {
        [TestMethod]
        public void SinglyLinkedListTest1()
        {
            string expectedListValues = "";
            SinglyLinkedList list = new SinglyLinkedList();

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }

        [TestMethod]
        public void SinglyLinkedListTest2()
        {
            string expectedListValues = "0";
            SinglyLinkedList list = new SinglyLinkedList();

            list.AddNodeToEnd("0");

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }

        [TestMethod]
        public void SinglyLinkedListTest3()
        {
            string expectedListValues = "0123456789";
            SinglyLinkedList list = new SinglyLinkedList();

            for (int i = 0; i < 10; i++)
            {
                list.AddNodeToEnd(i.ToString());
            }

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }

        [TestMethod]
        public void SinglyLinkedListTest4()
        {
            string expectedListValues = "123456789";
            SinglyLinkedList list = new SinglyLinkedList();

            for (int i = 0; i < 10; i++)
            {
                list.AddNodeToEnd(i.ToString());
            }

            Node currentNode = list.GetFirstNode();
            currentNode = list.DeleteCurrentNode();

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }

        [TestMethod]
        public void SinglyLinkedListTest5()
        {
            string expectedListValues = "012345678";
            SinglyLinkedList list = new SinglyLinkedList();

            for (int i = 0; i < 10; i++)
            {
                list.AddNodeToEnd(i.ToString());
            }

            Node currentNode = list.GetFirstNode();
            while (currentNode != null)
            {
                if (list.IsEndOfList())
                {
                    currentNode = list.DeleteCurrentNode();
                }
                else
                {
                    currentNode = list.GetNextNode();
                }
            }

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }

        [TestMethod]
        public void SinglyLinkedListTest6()
        {
            string expectedListValues = "012456789";
            SinglyLinkedList list = new SinglyLinkedList();

            for (int i = 0; i < 10; i++)
            {
                list.AddNodeToEnd(i.ToString());
            }

            Node currentNode = list.GetFirstNode();
            currentNode = list.GetNextNode();
            currentNode = list.GetNextNode();
            currentNode = list.GetNextNode();
            currentNode = list.DeleteCurrentNode();

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }

        [TestMethod]
        public void SinglyLinkedListTest7()
        {
            string expectedListValues = "012311456789";
            SinglyLinkedList list = new SinglyLinkedList();

            for (int i = 0; i < 10; i++)
            {
                list.AddNodeToEnd(i.ToString());
            }

            Node currentNode = list.GetFirstNode();
            currentNode = list.GetNextNode();
            currentNode = list.GetNextNode();
            currentNode = list.GetNextNode();
            list.InsertNodeAfter(new Node("11"));

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }

        [TestMethod]
        public void SinglyLinkedListTest40()
        {
            string expectedListValues = "The man in the moon likes gouda.";
            SinglyLinkedList list = new SinglyLinkedList();

            list.AddNodeToEnd("The ");
            list.AddNodeToEnd("man ");
            list.AddNodeToEnd("in ");
            list.AddNodeToEnd("the ");
            list.AddNodeToEnd("moon ");
            list.AddNodeToEnd("likes ");
            list.AddNodeToEnd("gouda.");

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }

        [TestMethod]
        public void SinglyLinkedListTest50()
        {
            string expectedListValues = "01234567891011121314151617181920212223242526272829303132333435363738394041424344" +
                                            "45464748495051525354555657585960616263646566676869707172737475767778798081828384" +
                                            "85868788899091929394959697989910010110210310410510610710810911011111211311411511" +
                                            "61171181191201211221231241251261271281291301311321331341351361371381391401411421" +
                                            "43144145146147148149150151152153154155156157158159160161162163164165166167168169" +
                                            "17017117217317417517617717817918018118218318418518618718818919019119219319419519" +
                                            "61971981992002012022032042052062072082092102112122132142152162172182192202212222" +
                                            "23224225226227228229230231232233234235236237238239240241242243244245246247248249" +
                                            "25025125225325425525625725825926026126226326426526626726826927027127227327427527" +
                                            "62772782792802812822832842852862872882892902912922932942952962972982993003013023" +
                                            "03304305306307308309310311312313314315316317318319320321322323324325326327328329" +
                                            "33033133233333433533633733833934034134234334434534634734834935035135235335435535" +
                                            "63573583593603613623633643653663673683693703713723733743753763773783793803813823" +
                                            "83384385386387388389390391392393394395396397398399400401402403404405406407408409" +
                                            "41041141241341441541641741841942042142242342442542642742842943043143243343443543" +
                                            "64374384394404414424434444454464474484494504514524534544554564574584594604614624" +
                                            "63464465466467468469470471472473474475476477478479480481482483484485486487488489" +
                                            "49049149249349449549649749849950050150250350450550650750850951051151251351451551" +
                                            "65175185195205215225235245255265275285295305315325335345355365375385395405415425" +
                                            "43544545546547548549550551552553554555556557558559560561562563564565566567568569" +
                                            "57057157257357457557657757857958058158258358458558658758858959059159259359459559" +
                                            "65975985996006016026036046056066076086096106116126136146156166176186196206216226" +
                                            "23624625626627628629630631632633634635636637638639640641642643644645646647648649" +
                                            "65065165265365465565665765865966066166266366466566666766866967067167267367467567" +
                                            "66776786796806816826836846856866876886896906916926936946956966976986997007017027" +
                                            "03704705706707708709710711712713714715716717718719720721722723724725726727728729" +
                                            "73073173273373473573673773873974074174274374474574674774874975075175275375475575" +
                                            "67577587597607617627637647657667677687697707717727737747757767777787797807817827" +
                                            "83784785786787788789790791792793794795796797798799800801802803804805806807808809" +
                                            "81081181281381481581681781881982082182282382482582682782882983083183283383483583" +
                                            "68378388398408418428438448458468478488498508518528538548558568578588598608618628" +
                                            "63864865866867868869870871872873874875876877878879880881882883884885886887888889" +
                                            "89089189289389489589689789889990090190290390490590690790890991091191291391491591" +
                                            "69179189199209219229239249259269279289299309319329339349359369379389399409419429" +
                                            "43944945946947948949950951952953954955956957958959960961962963964965966967968969" +
                                            "97097197297397497597697797897998098198298398498598698798898999099199299399499599" +
                                            "6997998999";
            SinglyLinkedList list = new SinglyLinkedList();

            for (int i = 0; i < 1000; i++)
            {
                list.AddNodeToEnd(i.ToString());
            }

            string actualListValues = list.OutputNodeValuesToString();

            Assert.AreEqual(expectedListValues, actualListValues);
        }
    }
}
