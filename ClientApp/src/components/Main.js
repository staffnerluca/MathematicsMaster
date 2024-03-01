import React, { useState, useEffect } from 'react';
import './main.css';
var Latex = require("react-latex");


export function Main() {
    const [card, setCard] = useState(null);
    const [latexContent, setLatexContent] = useState(`What is $(3\\times 4) \\sum \\div (5-3)$`);
    useEffect(() => {
        // Load the initial task when the component mounts
        loadTask();
    }, []);


    async function loadTask() {
        try {
            const data = await getDataFromServer();
            setCard(data);
        } catch (error) {
            console.error("Error loading task:", error);
        }
    }


    async function getDataFromServer() {
        try {
            const response = await fetch("task", {
                headers: {
                    'Accept': 'application/json',
                },
            });

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }

            const card = await response.json();
            console.log("Got something from Tasks:\n", card);
            return card;
        } catch (error) {
            console.error("Error fetching data:", error.message);
            throw error; // Re-throw the error to handle it in the caller
        }
    }


    function DisplayUserInfo() {
        return (
            <div>
                <p>One day there will be info about the user here</p>
            </div>
        );
    }


    function QuestionField() {
        if (!card) {
            return null; 
        }

        return (
            <div>
                <p id="type">Art: {card.type}</p>
                <p id="points">Mögliche Punkte: {card.points}</p>
                <p className="lblQuestion" id="question">{card.question}</p>
            </div>
        );
    }


    function AnswerField() {
        if (!card) {
            return null;
        }

        return (
            <div>
                <textarea id="taAnswer"></textarea><br></br>
                <button className="btn btn-primary" id="check">Check</button>
                <button className="btn btn-primary" id="showAnswer">Show Answer</button>
            </div>
        );
    }


    function CompiledLatexNote(){
        //const content = `What is $(3\\times 4) \\sum \\div (5-3)$`;
        return(<div>
                <Latex>{latexContent}</Latex>
        </div>)
    }


    function PureLatexNote(){
        return(
            <div>
                <textarea id="taLatexEditor" placeholder='Enter you Latex here'></textarea>
                <br></br>
                <button className="btn btn-primary" onClick={changeLatex}>Compile Latex</button>
            </div>
        )
    }


    function changeLatex(){
        const editor = document.getElementById("taLatexEditor");
        const editorText = editor.value;
        setLatexContent(latexContent+editorText);
    }


    return (
        <div>
            <center><h1>TASKS</h1></center><h1></h1>
            <button className='btn btn-primary' onClick={loadTask}>Load task</button>
            <div className='container d-flex justify-content-center align-items-center vh-100'>
                <div className='text-center'>
                    <DisplayUserInfo />
                    <QuestionField />
                    <AnswerField />
                    <br></br>
                    <PureLatexNote />
                    <CompiledLatexNote />
                </div>
            </div>
        </div>
    );
};