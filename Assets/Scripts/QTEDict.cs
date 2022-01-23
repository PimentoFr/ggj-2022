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
                new QTEItem("Put a white paper",            new List<string>(), AudioClipList.copierFill),
                new QTEItem("Do a copy",                    new List<string>(), AudioClipList.DefaultCorrect),
                new QTEItem("Take a paper",                 new List<string>(), AudioClipList.copierTake),
            }, new QTEItem[]{
                new QTEItem("Clean the glass",            new List<string>(), AudioClipList.DefaultCorrect),
                new QTEItem("Throw pictures",             new List<string>(), AudioClipList.copierDropPhotos),
                new QTEItem("Put a white paper",            new List<string>(), AudioClipList.copierFill),
                new QTEItem("Do a copy",                    new List<string>(), AudioClipList.DefaultCorrect),
                new QTEItem("Take a paper",                 new List<string>(), AudioClipList.copierTake),
            }, 3)},
        {TaskType.WATER_PLANT,       new QTEMission(
            new QTEItem[]{
                new QTEItem("Water the plant",            new List<string>(), AudioClipList.plantWater),
            }, new QTEItem[]{
                new QTEItem("Straight on the plan",       new List<string>(), AudioClipList.plantPlace),
                new QTEItem("Water the plant",            new List<string>(),  AudioClipList.plantWater),
            }, 3)},
        {TaskType.DEBUG_PC,       new QTEMission(
            new QTEItem[]{
                new QTEItem("Update Databases",             new List<string>(),  AudioClipList.computerUpdate),
                new QTEItem("Shutdown computer",            new List<string>(),  AudioClipList.computerSwitchOff),
                new QTEItem("Start computer",               new List<string>(),  AudioClipList.computerSwitchOn),
            }, new QTEItem[]{
                new QTEItem("Close Youtube",                new List<string>(),  AudioClipList.computerStopYoutube),
                new QTEItem("Update Databases",             new List<string>(),  AudioClipList.computerUpdate),
                new QTEItem("Shutdown computer",            new List<string>(),  AudioClipList.computerSwitchOff),
                new QTEItem("Start computer",               new List<string>(),  AudioClipList.computerSwitchOn),
            }, 3)},
        {TaskType.GET_BILL,       new QTEMission(
            new QTEItem[]{
                new QTEItem("Get the bill",                 new List<string>(),  AudioClipList.fileBill),

            }, new QTEItem[]{
                new QTEItem("Organize files",               new List<string>(),  AudioClipList.fileOrder),
                new QTEItem("Get the bill",                 new List<string>(),  AudioClipList.fileBill),
            }, 4)},
        {TaskType.CALL_CLIENT,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Type phone number",             new List<string>(),  AudioClipList.phoneType),
                new QTEItem("Bullshit with client",          new List<string>(),  AudioClipList.phoneBullshit),
                new QTEItem("Convince the client",           new List<string>(),  AudioClipList.phoneConvince),
            }, new QTEItem[] {
                new QTEItem("Apologize",                     new List<string>(),  AudioClipList.phoneApologize),
                new QTEItem("Type phone number",             new List<string>(),  AudioClipList.phoneType),
                new QTEItem("Bullshit with client",          new List<string>(),  AudioClipList.phoneBullshit),
                new QTEItem("Convince the client",           new List<string>(),  AudioClipList.phoneConvince),
        }, 3)},
        {TaskType.FILL_COFFEE,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Put the mug",                  new List<string>(),  AudioClipList.coffeePutMug),
                new QTEItem("Fill the resevoir",            new List<string>(),  AudioClipList.cofferFillWater),
                new QTEItem("Make a coffee",                new List<string>(),  AudioClipList.coffeeMake),
            }, new QTEItem[] {
                new QTEItem("Clean the mug",                new List<string>(),  AudioClipList.coffeeCleanMug),
                new QTEItem("Put the mug",                  new List<string>(),  AudioClipList.coffeePutMug),
                new QTEItem("Fill the resevoir",            new List<string>(),  AudioClipList.cofferFillWater),
                new QTEItem("Make a coffee",                new List<string>(),  AudioClipList.coffeeMake),
        }, 3)},
        {TaskType.SIGN_CONTRACT,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Choose the best pen",            new List<string>(),  AudioClipList.penChoose),
                new QTEItem("Damp the pen",                  new List<string>(),  AudioClipList.penMoisture),
                new QTEItem("Sign the contract",            new List<string>(),  AudioClipList.penSign),
            }, new QTEItem[] {
                new QTEItem("Collect fallen pens",           new List<string>(),  AudioClipList.penChoose),
                new QTEItem("Choose the best pen",           new List<string>(),  AudioClipList.penMoisture),
                new QTEItem("Damp the pen",                  new List<string>(),  AudioClipList.penMoisture),
                new QTEItem("Sign the contract",            new List<string>(),  AudioClipList.penSign),
        }, 3)},
        {TaskType.STAPLE_DOCUMENT,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Staple documents",            new List<string>(),  AudioClipList.agraferUse),
            }, new QTEItem[] {
                new QTEItem("Collect clips",                new List<string>(),  AudioClipList.agraferCollect),
                new QTEItem("Staple documents",            new List<string>(),  AudioClipList.agraferUse),
        }, 3)},
        {TaskType.ORDER_FOLDER,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Order files",            new List<string>(),  AudioClipList.paperOrder),
            }, new QTEItem[] {
                new QTEItem("Unfold planes",            new List<string>(),  AudioClipList.paperUnfold),
                new QTEItem("Order files",            new List<string>(),  AudioClipList.paperOrder),
        }, 3)},
        {TaskType.REPLACE_POSTER,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Align poster",            new List<string>(),  AudioClipList.posterPlace),
            }, new QTEItem[] {
                new QTEItem("Clean poster",            new List<string>(),  AudioClipList.posterClean),
                new QTEItem("Align poster",            new List<string>(),  AudioClipList.posterPlace),
        }, 3)},
        {TaskType.REPLACE_CHAIR,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Place the chair",            new List<string>(),  AudioClipList.chairMove),
            }, new QTEItem[] {
                new QTEItem("Remove farting bag",         new List<string>(),  AudioClipList.chairFartingBag),
                new QTEItem("Place the chair",            new List<string>(),  AudioClipList.chairMove),
        }, 3)},
        {TaskType.WRITE_AGENDA,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Write the agenda",         new List<string>(),  AudioClipList.DefaultCorrect),
            }, new QTEItem[] {
                new QTEItem("Clean the paperboard",     new List<string>(),  AudioClipList.DefaultCorrect),
                new QTEItem("Write the agenda",         new List<string>(),  AudioClipList.DefaultCorrect),
        }, 3)},
    };

}

