import React, { Component, useState, useEffect } from 'react';
import {Link} from "react-router-dom";


export function CreateGroup(){
    const [user, setUser] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        // Load the initial user data when the component mounts
        const us = JSON.parse(localStorage.getItem('user'));
        if (us) {
            setUser(us);
            setLoading(false);
        } else {
            alert('Error: No user found');
            setLoading(false);
        }
    }, []);


    function CreateGroupBox(){
        console.log(user);
        return(
            <div className='createThings'>
                <p>Group name (will be used to join the group and must be unique): </p>
                <input id="inpGroupName"></input>
            </div>
        )
    }
    
    
    async function askServerToCreateGroup() {
        alert("hello");
        const groupName = document.getElementById("inpGroupName").value;
    
            try {
                const groupData = {
                    name : groupName,
                    userid: user.id
                };
    
                const response = await fetch("group", {
                    method: "POST",
                    headers: { "Content-type": "application/json" },
                    body: JSON.stringify(groupData)
                });
    
                if (!response.ok) {
                    throw new Error(`Server returned ${response.status}: ${response.statusText}`);
                }
    
                console.log("Group created successfully");
                // Handle response if needed
                // const data = await response.json();
                // console.log(data);
            } catch (error) {
                console.error("An error occurred!", error);
                alert("An error occurred while creating the group: " + error.message);
            }
    }
    
    /*
    async function doesGroupExist(groupName) {
        try {
            const idPath = "?id=" + user.id;
            const response = await fetch('group' + idPath + "&?name=" + groupName, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
            });
    
            if (!response.ok) {
                throw new Error('Something went wrong');
            }
    
            const exists = await response.json();
            console.log(exists);
            return exists; 
        } catch (error) {
            console.error('Error:', error);
            alert('Error communicating with the server.');
            return true; // Change to true when the server is functioning, for testing purposes
        }
    }*/
    
    return(
        <div className='container d-flex justify-content-center align-items-center vh-100'>
            <div className='text-center'>
                <CreateGroupBox />
                <br></br>
                <button className='btn btn-primary' onClick={askServerToCreateGroup}>Create Group</button>
            </div>
        </div>
    )
}