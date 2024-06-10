import React, { useState, useEffect } from 'react';
import './main.css';
import 'katex/dist/katex.min.css';
var Latex = require("react-latex");

export function Main() {
    const [card, setCard] = useState(null);
    const [latexContent, setLatexContent] = useState('');
    const [drawing, setDrawing] = useState(false);
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


    async function loadTask() {
        try {
            const data = await getDataFromServer();
            setCard(data);
        } catch (error) {
            alert('Internal Server error');
            let c = {
                type: 'A',
                points: 500,
                question: 'Why is this not working?',
                answer: "We don't have a clue. If it stays down contact our support team"
            };
            setCard(c);
        }
    }


    async function getDataFromServer() {
        try {
            const opt = "?nr=" + user.id;

            const response = await fetch('task'+opt, {
                headers: {
                    method: 'GET',
                    Accept: 'application/json',
                }
            });

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }

            const card = await response.json();
            return card;
        } catch (error) {
            console.error('Error fetching data:', error.message);
            throw error;
        }
    }


    function DisplayUserInfo() {
        if (loading) {
            return <div>User data is loading...</div>;
        }
        if (user) {
            const { username, points, group, usertype } = user;
            const type = usertype === 't' ? 'Teacher' : 'Student';
            const usersGroup = group == 1 ? 'No group' : group;
            return (
                <div id="userInfo" style={{ border: '1px solid black', padding: '10px', margin: '20px' }}>
                    <p>Hello {username}</p>
                    <p>You have {points} points and you are logged in as a {type}</p>
                    <p>Your group is {group}</p>
                </div>
            );
        }
        return null;
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
                <textarea id="taAnswer"></textarea><br />
                <button className="btn btn-primary" id="check">Check</button>
                <button className="btn btn-primary" id="showAnswer">Show Answer</button>
            </div>
        );
    }


    function CompiledLatexNote() {
        return (
            <div>
                <Latex output="mathml">{latexContent}</Latex>
            </div>
        );
    }


    function PureLatexNote() {
        return (
            <div>
                <textarea id="taLatexEditor" placeholder='Enter your Latex here'></textarea><br />
                <button className="btn btn-primary" onClick={changeLatex}>Compile Latex</button>
                <button className="btn btn-primary" onClick={clearLatex}>Clear</button>
            </div>
        );
    }


    function changeLatex() {
        const editor = document.getElementById('taLatexEditor');
        const editorText = editor.value;
        setLatexContent(latexContent + editorText);
    }


    function clearLatex() {
        setLatexContent('');
    }


    function DrawingField() {
        if (drawing) {
            return (
                <div className='drawingField'>
                    <h1>The drawing field</h1>
                </div>
            );
        }
        return null;
    }


    function RenderDrawingOrLatex() {
        if (drawing) {
            return <DrawingField />;
        }
        return (
            <div>
                <PureLatexNote />
                <CompiledLatexNote />
            </div>
        );
    }

    
    return (
        <div>
            <center><h1>TASKS</h1></center>
            <button className='btn btn-primary' onClick={loadTask}>Load task</button>
            <div className='container d-flex justify-content-center align-items-center vh-100'>
                <div className='mainContent'>
                    <div className='text-center'>
                        <DisplayUserInfo />
                        <QuestionField />
                        <AnswerField />
                    </div>
                    <br />
                    <div className='sidebar'>
                        <RenderDrawingOrLatex />
                        <button className='btnLatexOrDrawing btn btn-primary' onClick={() => setDrawing(!drawing)}>{drawing ? "Latex" : "Drawing"}</button>
                    </div>
                </div>
            </div>
        </div>
    );
}
