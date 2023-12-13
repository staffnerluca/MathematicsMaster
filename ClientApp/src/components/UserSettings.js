import React, { Component, useState } from 'react';

function getUserData(){
    const userData = {
        name: "Lukas",
        darkmode: false,
        mail: "billiardIsLove@saustall.pool",
        type: "t",
        group: 1
    }
    return userData;
}

export function UserSettings(){
    const [settingType, setSettingType] = ["account"];
    const [settingContent, setSettingsContent] = useState([<h1>Select a setting</h1>])
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

    function DifficultySelection(){
        return(
            <div>
                 Difficulty: <select>
                    <option value={0}>Luggi (easy)</option>
                    <option value={1}>Alex (mid)</option>
                    <option value={2}>Einstein (hard)</option>
                    <option value={3}>God (very very hard)</option>
                </select>
                Setting for: <select>
                    <option>Algebra</option>
                    <option>Geometry</option>
                    <option>Logic</option>
                    <option>All</option>
                </select>
            </div>
        )
       
    }
    function GroupSettings(){
        let user = getUserData();
        if(user.type === "t"){
            return(
                setSettingsContent([<div className='divGroupSettings'>
                    <h1>Group settings for teachers</h1>
                    <p>Add user: </p><input></input>
                    <p>Remove user: </p><input></input>
                    <DifficultySelection/>
                    <p>Force difficulty setting: <input type='check'></input></p>
                </div>])
            )
        }
        else if(user.group !== null){
            return(
                <div className='divGroupSettings'>
                    <h1>Group Settings for students</h1>
                </div>
            )
            
        }
        alert("Still here");
        return(
            <div className='divGroupSettings'>
                <h1>You ar not in a group</h1>
                <p>Send a request to join a group</p>
                <button>Join</button>
            </div>
        )
    }

    function AlgorithmSettings(){
        return(
            <div className="divAlgoSettings">
                <h1>Settings for the Algorithm</h1>
                <div className='settings'>
                    Difficulty: <select>
                        <option value={0}>Luggi (easy)</option>
                        <option value={1}>Alex (mid)</option>
                        <option value={2}>Einstein (hard)</option>
                        <option value={3}>God (very very hard)</option>
                    </select>
                    Setting for: <select>
                        <option>Algebra</option>
                        <option>Geometry</option>
                        <option>Logic</option>
                        <option>All</option>
                    </select>
                </div>
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
            <button id="btnAccount" onClick={AccountSettings}>Account</button>
            <button id="btnGroup" onClick={GroupSettings}>Group</button>
            <button id="btnAlgo"onClick={AlgorithmSettings}>Algorithm</button>
            {settingContent}
            <ShowSettings/>
        </div>
        )
}