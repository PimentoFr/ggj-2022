using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QTEMission
{
    public QTEItem[] items { get; set; }
    public QTEItem[] itemsRepair { get; set; }
    public int difficulties { get; set; }

    public QTEMission(QTEItem[] _items, QTEItem[] _itemsRepair, int _difficulties)
    {
        items = _items;
        itemsRepair = _itemsRepair;
        difficulties = _difficulties;
    }

    public QTEItem[] GetQTEItems(bool chaos)
    {
        return (chaos) ? itemsRepair : items;
    }
}

public static class QTEMissions
{

    public static Dictionary<TaskType, QTEMission> missions = new Dictionary<TaskType, QTEMission>() {
        {TaskType.FILL_COFFEE,       new QTEMission(
            new QTEItem[]{
                new QTEItem("Mettre le mug",                new List<string>()),
                new QTEItem("Remplir le reservoir",         new List<string>()),
                new QTEItem("Faire un cafe",                new List<string>()),
            }, new QTEItem[]{
                new QTEItem("Nettoyer le mug",              new List<string>()),
                new QTEItem("Mettre le mug",                new List<string>()),
                new QTEItem("Remplir le reservoir",         new List<string>()),
                new QTEItem("Faire un cafe",                new List<string>()),
            }, 4)},
        {TaskType.COPY_DOCUMENT,       new QTEMission(
            new QTEItem[]{
                new QTEItem("Prendre une feuille",          new List<string>()),
                new QTEItem("Imprimer",                     new List<string>()),
                new QTEItem("Prendre la copie",             new List<string>()),
            }, new QTEItem[]{
                new QTEItem("Nettoyer la vitre",            new List<string>()),
                new QTEItem("Prendre une feuille",          new List<string>()),
                new QTEItem("Imprimer",                     new List<string>()),
                new QTEItem("Prendre la copie",             new List<string>()),
            }, 4)},
        {TaskType.WATER_PLANT,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Arroser la plante",           new List<string>()),
            }, new QTEItem[] {
                new QTEItem("Redresser la plante",         new List<string>()),
                new QTEItem("Arroser la plante",           new List<string>()),
        }, 4)},
        {TaskType.REPLACE_CHAIR,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Remettre la chaise",           new List<string>()),
            }, new QTEItem[] {
                new QTEItem("Enlever le coussin peteur",    new List<string>()),
                new QTEItem("Remettre la chaise",           new List<string>()),
        }, 3)},
    };

}

