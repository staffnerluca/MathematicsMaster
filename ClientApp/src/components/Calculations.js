import React, { Component } from 'react';

function createTwoRandomNumbers(maxfirst, maxsecond, condition = () => true) {
    let maxTrys = 100;
    let i = 0;

    while (i < maxTrys) {
        let first = Math.floor(Math.random() * maxfirst + 1);
        let second = Math.floor(Math.random() * maxsecond + 1);
        if (condition(first, second)) {
            return [first, second];
        }
        i++;
    }
    return [0, 0];
}


function CreateMultiplication({ id }) {
    let max = 9;
    let [first, second] = createTwoRandomNumbers(max, max);
    let idC = "c" + id;
    let idI = "i" + id; 
    return (
        <p id={idC} className='calc'>{first} * {second} = <input id={idI} className='calInp'></input></p>
    );
}


function CreateDivision({ id }) {
    let maxf = 100;
    let maxs = 10;
    let idC = "c" + id;
    let idI = "i" + id;
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x % y === 0 && x / y < 10);
    return (
        <p id={idC} className='calc'>{first} : {second} = <input id={idI} className='calInp'></input></p>
    );
}


function CreateSubtraction({ id }) {
    let maxf = 99;
    let maxs = 99;
    let idC = "c" + id;
    let idI = "i" + id;
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x >= y);
    return (
        <p id={idC} className='calc'>{first} - {second} = <input id={idI} className='calInp'></input></p>
    );
}


function CreateAddition({ id }) {
    let maxf = 99;
    let maxs = 99;
    let idC = "c" + id;
    let idI = "i" + id;
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x + y < 100);
    return (
        <p id={idC} className='calc'>{first} + {second} = <input id={idI} className='calInp'></input></p>
    );
}


function CreateTwentyFiveCalculations({ type }) {
    let components = [];
    let ComponentType;

    switch (type) {
        case "1":
            ComponentType = CreateAddition;
            break;
        case "2":
            ComponentType = CreateSubtraction;
            break;
        case "3":
            ComponentType = CreateMultiplication;
            break;
        case "4":
            ComponentType = CreateDivision;
            break;
        default:
            ComponentType = CreateAddition;
    }

    for (let i = 0; i < 25; i++) {
        components.push(<ComponentType key={i} id={i} />);
    }
    
    return <div className='TwentyFiveCalcs'>{components}</div>;
}


function checkCalculations(option) {
    for (let i = 0; i < 100; i++) {
        let calcCo = document.getElementById("c" + i);
        let resultCo = document.getElementById("i" + i);
        if (calcCo !== null) {
            let text = calcCo.textContent;
            let txt = text.split(" ");
            let firstNum = parseInt(txt[0]);
            let secondNum = parseInt(txt[2]);
            let result = parseInt(resultCo.value);
            let correct = false;

            if (option === "1" && firstNum + secondNum === result) {
                correct = true;
            } 
            else if (option === "2" && firstNum - secondNum === result) {
                correct = true;
            } 
            else if (option === "3" && firstNum * secondNum === result) {
                correct = true;
            } 
            else if (option === "4" && firstNum / secondNum === result) {
                correct = true;
            }

            if (resultCo.value !== "") {
                if (correct) {
                    resultCo.classList.add("correct");
                } else {
                    resultCo.classList.add("false");
                }
            }
        }
    }
}


function getCalculationsType(option) {
    switch (option) {
        case "1":
            return "a";
        case "2":
            return "s";
        case "3":
            return "m";
        case "4":
            return "d";
        default:
            return "a";
    }
}


function download(option) {
    const opt = "?type=" + getCalculationsType(option);
    fetch('calculation' + opt)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.blob();
        })
        .then(blob => {
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = "calculations.pdf";
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
        })
        .catch(error => {
            console.error('There was a problem with your fetch operation:', error);
        });
}


export class CreateCalculationsForPrimarySchool extends Component {
    constructor(props) {
        super(props);
        this.state = { option: "1" };
    }

    selectionChange = (event) => {
        this.setState({
            option: event.target.value
        });
    };

    render() {
        const { option } = this.state;

        return (
            <div>
                <center><h1>Calculations</h1></center>
                <button className="btn btn-primary" onClick={() => download(option)}>Download</button>
                <button className="btn btn-primary" onClick={() => checkCalculations(option)}>Check</button>

                <select className="selectpicker form-control border-0 mb-1 px-4 py-4 rounded shadow" id="comType" onChange={this.selectionChange} value={option}>
                    <option value="1">Addition</option>
                    <option value="2">Subtraction</option>
                    <option value="3">Multiplication</option>
                    <option value="4">Division</option>
                </select>
                <div className='container'>
                    <div className='column'>
                        <CreateTwentyFiveCalculations type={option} />
                    </div>
                    <div className='column'>
                        <CreateTwentyFiveCalculations type={option} />
                    </div>
                    <div className='column'>
                        <CreateTwentyFiveCalculations type={option} />
                    </div>
                    <div className='column'>
                        <CreateTwentyFiveCalculations type={option} />
                    </div>
                </div>
                <button className="btn btn-primary" onClick={() => checkCalculations(option)}>Check</button>
            </div>
        );
    }
}