import React, { Component } from 'react';
import {Link} from "react-router-dom";

function getUserData(){
    const userData = {
        name: "Lukas",
        darkmode: false,
        mail: "billiardIsLove@saustall.pool",
        type: "t"
    }
}

export function UserSettings(){
    const [settingType, setSettingType] = ["account"];
    let username = "luggi";
    function AccountSettings(){
        return(
            <div>
                <h1>Main Settings</h1>
                <div>
                   Username: {username} 
                </div>
            </div>
        )
    }

    function GroupSettings(){
        return(
            <div className='divGroupSettings'>
                <h1>Group Settings</h1>
            </div>
        )
    }

    function AlgorithmSettings(){
        return(
            <div className="divAlgoSettings">
                <h1>Settings for the Algorithm</h1>
            </div>
        )
    }
    
    function ShowSettings(){
        if(settingType === "account"){
            return <AccountSettings/>
        }
        else if(settingType === "group"){
            return <GroupSettings/>
        }
        else if(settingType === "algorithm"){
            return <AlgorithmSettings/>
        }
        return <h1>Nothing found</h1>
    }

    function btnChangeOtherSectionPressed(event){
        let bt = event.target.id;
        let btns = document.getElementsByTagName("button");
        //remove max value of task list when larger than one element
        /*for(b in btns){
            b.classList.pop();
        }*/
        document.getElementById(bt).classList.add("current");

    }

    return(
        <div className='userSettings'>
            <button id="btnAccount" onClick={btnChangeOtherSectionPressed}>Account</button>
            <button id="btnGroup" onClick={btnChangeOtherSectionPressed}>Group</button>
            <button id="btnAlgo"onClick={btnChangeOtherSectionPressed}>Algorithm</button>

            <ShowSettings/>
        </div>
        )
}