import { METHODS } from 'http';
import React, { Component, useEffect, useState } from 'react';


function CreateData(){
    const [option, setOption] = useState("");

    useEffect(() => {
        const op = window.location.pathname.split("/").pop();
        setOption(op);
    })

    function postData(){
        /*cmd.CommandText = "CREATE TABLE User([id] INT NOT NULL PRIMARY KEY IDENTITY, [username] NVARCHAR(50)), [E-Mail] NVARCHAR(80), [points] INT," +
                    " [userType] NVARCHAR(25), [lastLogin] DATETIME, [lastLogout] DATETIME, [darkmode] BOOL, [birthDate] DATETIME);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE UserAndGroups([UID] INT, [GID] INT);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE Group([id] INT NOT NULL PRIMARY KEY IDENTITY, [name] VARCHAR(50), [owner] INT);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE Institution([id] INT NOT NULL PRIMARY KEY IDENTITY, [address] NVARCHAR(100), [country] NVARCHAR(56)" +
                    ",[type] CHAR(1), [phoneNumber] NVARCHAR(20), [mail] NVARCHAR(40), [postalCode] NVARCHAR(16));";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE FinishedTasks([TaskID] INT, [UserID] INT, [Percent] FLOAT);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE Task([nr] INT, [name] NVARCHAR(50), [sector] CHAR(1), [difficulty] INT, [points] INT," +
                    "[drawing] BOOL, [question] NVARCHAR(3500), [answer] NVARCHAR(7500), [source] NVARCHAR(2000), [group] INT, [imagePath] NVARCHAR(1000));";
*/
        const data = getData();
        fetch(option, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: data,
        }).then(response => {
            if(response.ok){
                alert("Created succesefully");
            }
            else{
                alert("Something went wrong try again");
            }
        })     
    }

    function CreateUser(){
        return(
            <div className='creation'>
                <p>username: </p><input></input>
                <p>firstname: </p><input></input>
                <p>familyname: </p><input></input>
                <p>E-mail: </p><input></input>
                <p>Darkmode: </p><input type="checkbox"></input>
                <p>Name: </p><input></input>
                <p>Name: </p><input></input>

            </div>
        )
    }


    return(
        <div>{option}</div>
    )
}

export default CreateData();