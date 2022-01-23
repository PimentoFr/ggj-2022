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
                new QTEItem("Put a white paper",            new List<string>(), AudioType.COPIER_FILL),
                new QTEItem("Do a copy",                    new List<string>(), AudioType.DEFAULT_CORRECT),
                new QTEItem("Take a paper",                 new List<string>(), AudioType.COPIER_TAKE),
            }, new QTEItem[]{
                new QTEItem("Clean the glass",            new List<string>(), AudioType.DEFAULT_CORRECT),
                new QTEItem("Throw pictures",             new List<string>(), AudioType.COPIER_DROP_PICTURES),
                new QTEItem("Put a white paper",            new List<string>(), AudioType.COPIER_FILL),
                new QTEItem("Do a copy",                    new List<string>(), AudioType.DEFAULT_CORRECT),
                new QTEItem("Take a paper",                 new List<string>(), AudioType.COPIER_TAKE),
            }, 3)},
        {TaskType.WATER_PLANT,       new QTEMission(
            new QTEItem[]{
                new QTEItem("Water the plant",            new List<string>(), AudioType.PLANT_WATER),
            }, new QTEItem[]{
                new QTEItem("Straight on the plan",       new List<string>(), AudioType.PLANT_PLACE),
                new QTEItem("Water the plant",            new List<string>(),  AudioType.PLANT_WATER),
            }, 3)},
        {TaskType.DEBUG_PC,       new QTEMission(
            new QTEItem[]{
                new QTEItem("Update Databases",             new List<string>(),  AudioType.COMPUTER_UPDATE),
                new QTEItem("Shutdown computer",            new List<string>(),  AudioType.COMPUTER_SWITCH_OFF),
                new QTEItem("Start computer",               new List<string>(),  AudioType.COMPUTER_SWITCH_ON),
            }, new QTEItem[]{
                new QTEItem("Close Youtube",                new List<string>(),  AudioType.COMPUTER_RUN_YOUTUBE),
                new QTEItem("Update Databases",             new List<string>(),  AudioType.COMPUTER_UPDATE),
                new QTEItem("Shutdown computer",            new List<string>(),  AudioType.COMPUTER_SWITCH_OFF),
                new QTEItem("Start computer",               new List<string>(),  AudioType.COMPUTER_SWITCH_ON),
            }, 3)},
        {TaskType.GET_BILL,       new QTEMission(
            new QTEItem[]{
                new QTEItem("Get the bill",                 new List<string>(),  AudioType.FILE_BILL),

            }, new QTEItem[]{
                new QTEItem("Organize files",               new List<string>(),  AudioType.FILE_ORDER),
                new QTEItem("Get the bill",                 new List<string>(),  AudioType.FILE_BILL),
            }, 4)},
        {TaskType.CALL_CLIENT,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Type phone number",             new List<string>(),  AudioType.PHONE_TYPE),
                new QTEItem("Bullshit with client",          new List<string>(),  AudioType.PHONE_BULLSHIT),
                new QTEItem("Convince the client",           new List<string>(),  AudioType.PHONE_CONVINCE),
            }, new QTEItem[] {
                new QTEItem("Apologize",                     new List<string>(),  AudioType.PHONE_APOLOGIZE),
                new QTEItem("Type phone number",             new List<string>(),  AudioType.PHONE_TYPE),
                new QTEItem("Bullshit with client",          new List<string>(),  AudioType.PHONE_BULLSHIT),
                new QTEItem("Convince the client",           new List<string>(),  AudioType.PHONE_CONVINCE),
        }, 3)},
        {TaskType.FILL_COFFEE,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Put the mug",                  new List<string>(),  AudioType.COFFEE_PUT_MUG),
                new QTEItem("Fill the resevoir",            new List<string>(),  AudioType.COFFEE_FILL_WATER),
                new QTEItem("Make a coffee",                new List<string>(),  AudioType.COFFEE_MAKE),
            }, new QTEItem[] {
                new QTEItem("Clean the mug",                new List<string>(),  AudioType.COFFEE_CLEAN_MUG),
                new QTEItem("Put the mug",                  new List<string>(),  AudioType.COFFEE_PUT_MUG),
                new QTEItem("Fill the resevoir",            new List<string>(),  AudioType.COFFEE_FILL_WATER),
                new QTEItem("Make a coffee",                new List<string>(),  AudioType.COFFEE_MAKE),
        }, 3)},
        {TaskType.SIGN_CONTRACT,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Choose the best pen",            new List<string>(),  AudioType.PEN_CHOOSE),
                new QTEItem("Damp the pen",                  new List<string>(),  AudioType.PEN_MOISTURE),
                new QTEItem("Sign the contract",            new List<string>(),  AudioType.PEN_SIGN),
            }, new QTEItem[] {
                new QTEItem("Collect fallen pens",           new List<string>(),  AudioType.PEN_PICK),
                new QTEItem("Choose the best pen",           new List<string>(),  AudioType.PEN_CHOOSE),
                new QTEItem("Damp the pen",                  new List<string>(),  AudioType.PEN_MOISTURE),
                new QTEItem("Sign the contract",            new List<string>(),  AudioType.PEN_SIGN),
        }, 3)},
        {TaskType.STAPLE_DOCUMENT,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Staple documents",            new List<string>(),  AudioType.AGRAFER_USE),
            }, new QTEItem[] {
                new QTEItem("Collect clips",                new List<string>(),  AudioType.AGRAFER_COLLECT),
                new QTEItem("Staple documents",            new List<string>(),  AudioType.AGRAFER_USE),
        }, 3)},
        {TaskType.ORDER_FOLDER,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Order files",            new List<string>(),  AudioType.PAPER_ORDER),
            }, new QTEItem[] {
                new QTEItem("Unfold planes",            new List<string>(),  AudioType.PAPER_UNFOLD),
                new QTEItem("Order files",            new List<string>(),  AudioType.PAPER_ORDER),
        }, 3)},
        {TaskType.REPLACE_POSTER,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Align poster",            new List<string>(),  AudioType.POSTER_PLACE),
            }, new QTEItem[] {
                new QTEItem("Clean poster",            new List<string>(),  AudioType.POSTER_CLEAN),
                new QTEItem("Align poster",            new List<string>(),  AudioType.POSTER_PLACE),
        }, 3)},
        {TaskType.REPLACE_CHAIR,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Place the chair",            new List<string>(),  AudioType.CHAIR_MOVE),
            }, new QTEItem[] {
                new QTEItem("Remove farting bag",         new List<string>(),  AudioType.CHAIR_FARTING_BAG),
                new QTEItem("Place the chair",            new List<string>(),  AudioType.CHAIR_MOVE),
        }, 3)},
        {TaskType.WRITE_AGENDA,          new QTEMission(
            new QTEItem[]{
                new QTEItem("Write the agenda",         new List<string>(),  AudioType.DEFAULT_CORRECT),
            }, new QTEItem[] {
                new QTEItem("Clean the paperboard",     new List<string>(),  AudioType.DEFAULT_CORRECT),
                new QTEItem("Write the agenda",         new List<string>(),  AudioType.DEFAULT_CORRECT),
        }, 3)},
    };

}

