import React, { useState, useEffect } from 'react';
import './main.css';
import 'katex/dist/katex.min.css';

var Latex = require("react-latex");

export function Main() {
    const [card, setCard] = useState(null);
    const [latexContent, setLatexContent] = useState(``);
    const [drawing, setDrawing] = useState(false);
    const [user, setUser] = useState({});
    const [name, setName] = useState();
    const [points, setPoints] = useState();
    const [group, setGroup] = useState();
    const [type, setType] = useState();
    const [id, setId] = useState();

    useEffect(() => {
        // Load the initial task when the component mounts
        loadTask();
        setUser(JSON.parse(localStorage.getItem("user")));
        console.log(user);
        setName(user["username"]);
        setPoints(user["points"]);
        setGroup(user["group"]);
        const tmp_type = user["usertype"];
        if(tmp_type == "t"){
            setType("Teacher");
        }
        else{
            setType("Student");
        }
    }, []);


    async function loadTask() {
        try {
            const data = await getDataFromServer();
            setCard(data);
            alert(name);
        } catch (error) {
            alert("Internal Server error");
            let c = {
                type: "A",
                points: 500,
                question: "Why is this not working?",
                answer: "We don't have a clue. If it stays down contact our support team"
            };
            setCard(c);
        }
    }


    async function getDataFromServer() {
        try {
            const response = await fetch("task", {
                headers: {
                    'method': 'POST',
                    'Accept': 'application/json',
                }
            });

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }

            const card = await response.json();
            console.log("Got something from Tasks:\n", card);
            return card;
        } catch (error) {
            console.error("Error fetching data:", error.message);
            throw error;
        }
    }


    function DisplayUserInfo() {
        return (
            <div id="userInfo" style={{ border: '1px solid black', padding: '10px', margin: "20px", }}>
                <p>Hello {name}</p>
                <p>You have {points} points and you are loged in as a {type}</p>
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
                <Latex output="mathml">{latexContent}</Latex>
        </div>)
    }


    function PureLatexNote(){
        return(
            <div>
                <textarea id="taLatexEditor" placeholder='Enter you Latex here'></textarea>
                <br></br>
                <button className="btn btn-primary" onClick={changeLatex}>Compile Latex</button>
                <button className="btn btn-primary" onClick={clearLatex}>Clear</button>
            </div>
        )
    }


    function changeLatex(){
        const editor = document.getElementById("taLatexEditor");
        const editorText = editor.value;
        setLatexContent(latexContent+editorText);
    }


    function clearLatex(){
        setLatexContent(``);
    }


    function DrawingField(){
        if(drawing){
            return(<div className='drawingField'>
                <h1>the drawing field</h1>
            </div>)
        }
        return(
            <div>
                <button onClick={changeDrawing()}>Draw</button>
            </div>
        )
    }


    function changeDrawing(){
        const draw = !drawing;
        setDrawing(draw);
    }

    
    function getStringFromDrawing(){
        if(drawing){
            return "Latex";
        }
        else{
            return "Drawing";
        }
    }
    
    
    function RenderDrawingOrLatex(){
        if(drawing){
            return(
                <div>
                    <DrawingField />
                </div>
            )
        }
        else{
            return(
                <div>
                    <PureLatexNote />
                    <CompiledLatexNote />
                </div>
            )
        }
    }


    return (
        <div>
            <center><h1>TASKS</h1></center><h1></h1>
            <button className='btn btn-primary' onClick={loadTask}>Load task</button>
            <div className='container d-flex justify-content-center align-items-center vh-100'>
                <div className='mainContent'>
                    <div className='text-center'>
                        <DisplayUserInfo />
                        <QuestionField />
                        <AnswerField />
                    </div>
                    <br></br>
                    <div className='sidebar'>
                        <RenderDrawingOrLatex />
                        <button className='btnLatexOrDrawing btn btn-primary' onClick={x => setDrawing(!drawing)}>{getStringFromDrawing()}</button>
                    </div>
                </div>
            </div>
        </div>
    );
};