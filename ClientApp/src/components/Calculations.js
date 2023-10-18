import React, { Component } from 'react';
import "./calculations.css";


function createTwoRandomNumbers(maxf, maxs, condition = () => true){
    let maxTrys = 100;
    let i = 0;
    while(i < maxTrys){
        let first = Math.floor(Math.random() * maxf + 1);
        let second = Math.floor(Math.random() * maxs + 1);
        if(condition(first, second)){
            return [first, second];
        }
        i++;
    }
    return [0, 0]
}

function CreateMultiplication(){
    let max = 9;
    //alert(toString(id));
    let [first, second] = createTwoRandomNumbers(max, max);
    return(
        <p>{first} * {second} = <input></input></p>
    )
}

function CreateDivision(){
    let maxf = 100;
    let maxs = 10;
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x % y === 0 && x/y < 10)
    return(
        <p>{first} : {second} = <input></input></p>
    )
}

function CreateSubtraction(){
    let maxf = 99;
    let maxs = 99;
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x >= y);
    return(
        <p>{first} : {second} = <input></input></p>
    )
}

function CreateAddition(){
    let maxf = 99;
    let maxs = 99;
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x+y < 100)
    return <p>{first} + {second} = <input></input></p>
}


function CreateHundredCalculations(type) {
    let comps = [];
    if(type == "1"){
        for(let i = 0; i < 100; i++){
            comps.push(<CreateAddition key={i} id={i}/>)
        }
    }
    else if(type == "2"){
        for(let i = 0; i < 100; i++){
            comps.push(<CreateSubtraction key={i}/>)
        }
    }
    else if(type === "3"){
        for(let i = 0; i < 100; i++){
            comps.push(<CreateMultiplication key={i} id={i}/>)
        }
    }
    else if(type == "4"){
        for(let i=0; i < 100; i++){
            comps.push(<CreateDivision key={i}/>)
        }
    }
    return <div>{comps}</div>

  }

function checkCalculations(option){
    alert("Checking");
    for(let i = 0; i > 100; i++){
        let calc = document.getElementById("c"+i).textContent;
        let txt = calc.splitText(" ");
        let firstNum = txt[0];
        let secondNum = txt[2];
        let result = document.getElementById("i"+i);
        let resTxt = result.textContent;
        let correct = false;
        if (option === "1" && firstNum+secondNum == resTxt){
            correct = true;
        }
        else if(option === "2" && firstNum-secondNum == resTxt){
            correct = true;
        }
        else if(option === "3" && firstNum*secondNum == resTxt){
            correct = true;
        }
        else if(option === "4" && firstNum/secondNum == resTxt){
            correct = true;
        }
        if(correct){
            //change class of inp to correct
            result.classList.add("correct");
        }
        else{
            //change class to false
            result.classList.add("false");
        }

    }
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
                <h1>Calculations</h1>
                <select id="comType" onChange={this.selectionChange} value={option}>
                    <option value="1">Addition</option>
                    <option value="2">Subtraction</option>
                    <option value="3">Multiplication</option>
                    <option value="4">Division</option>
                </select>
                {CreateHundredCalculations(option)}
                <button onClick={checkCalculations}>Check</button>
            </div>
        );
    }
}