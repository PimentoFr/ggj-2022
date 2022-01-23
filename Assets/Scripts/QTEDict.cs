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
        {TaskType.COPY_DOCUMENT,       new QTEMission(
            new QTEItem[]{
                new QTEItem("Put a white paper",            new List<string>()),
                new QTEItem("Do a copy",                    new List<string>()),
                new QTEItem("Take a paper",                 new List<string>()),
            }, new QTEItem[]{
                new QTEItem("Clean the glass",            new List<string>()),
                new QTEItem("Throw pictures",             new List<string>()),
                new QTEItem("Put a white paper",            new List<string>()),
                new QTEItem("Do a copy",                    new List<string>()),
                new QTEItem("Take a paper",                 new List<string>()),
            }, 3)},
        {TaskType.WATER_PLANT,       new QTEMission(
            new QTEItem[]{
                new QTEItem("Water the plant",            new List<string>()),
            }, new QTEItem[]{
                new QTEItem("Straight on the plan",       new List<string>()),
                new QTEItem("Water the plant",            new List<string>()),
            }, 3)},
        {TaskType.DEBUG_PC,       new QTEMission(
            new QTEItem[]{
                new QTEItem("Update Databases",             new List<string>()),
                new QTEItem("Shutdown computer",            new List<string>()),
                new QTEItem("Start computer",               new List<string>()),
            }, new QTEItem[]{
                new QTEItem("Close Youtube",                new List<string>()),
                new QTEItem("Update Databases",             new List<string>()),
                new QTEItem("Shutdown computer",            new List<string>()),
                new QTEItem("Start computer",               new List<string>()),
            }, 3)},
        {TaskType.GET_BILL,       new QTEMission(
            new QTEItem[]{
                new QTEItem("Get the bill",                 new List<string>()),

            }, new QTEItem[]{
                new QTEItem("Organize files",               new List<string>()),
                new QTEItem("Get the bill",                 new List<string>()),
            }, 4)},
        {TaskType.CALL_CLIENT,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Type phone number",             new List<string>()),
                new QTEItem("Bullshit with client",          new List<string>()),
                new QTEItem("Convince the client",           new List<string>()),
            }, new QTEItem[] {
                new QTEItem("Apologize",                     new List<string>()),
                new QTEItem("Type phone number",             new List<string>()),
                new QTEItem("Bullshit with client",          new List<string>()),
                new QTEItem("Convince the client",           new List<string>()),
        }, 3)},
        {TaskType.FILL_COFFEE,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Put the mug",                  new List<string>()),
                new QTEItem("Fill the resevoir",            new List<string>()),
                new QTEItem("Make a coffee",                new List<string>()),
            }, new QTEItem[] {
                new QTEItem("Clean the mug",                new List<string>()),
                new QTEItem("Put the mug",                  new List<string>()),
                new QTEItem("Fill the resevoir",            new List<string>()),
                new QTEItem("Make a coffee",                new List<string>()),
        }, 3)},
        {TaskType.SIGN_CONTRACT,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Choose the best pen",            new List<string>()),
                new QTEItem("Damp the pen",                  new List<string>()),
                new QTEItem("Sign the contract",            new List<string>()),
            }, new QTEItem[] {
                new QTEItem("Collect fallen pens",           new List<string>()),
                new QTEItem("Choose the best pen",           new List<string>()),
                new QTEItem("Damp the pen",                  new List<string>()),
                new QTEItem("Sign the contract",            new List<string>()),
        }, 3)},
        {TaskType.STAPLE_DOCUMENT,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Staple documents",            new List<string>()),
            }, new QTEItem[] {
                new QTEItem("Collect clips",                new List<string>()),
                new QTEItem("Staple documents",            new List<string>()),
        }, 3)},
        {TaskType.ORDER_FOLDER,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Order files",            new List<string>()),
            }, new QTEItem[] {
                new QTEItem("Unfold planes",            new List<string>()),
                new QTEItem("Order files",            new List<string>()),
        }, 3)},
        {TaskType.REPLACE_POSTER,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Align poster",            new List<string>()),
            }, new QTEItem[] {
                new QTEItem("Clean poster",            new List<string>()),
                new QTEItem("Align poster",            new List<string>()),
        }, 3)},
        {TaskType.REPLACE_CHAIR,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Place the chair",            new List<string>()),
            }, new QTEItem[] {
                new QTEItem("Remove farting bag",         new List<string>()),
                new QTEItem("Plain the chair",            new List<string>()),
        }, 3)},
        {TaskType.WRITE_AGENDA,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Write the agenda",         new List<string>()),
            }, new QTEItem[] {
                new QTEItem("Clean the paperboard",     new List<string>()),
                new QTEItem("Write the agenda",         new List<string>()),
        }, 3)},
    };

}

