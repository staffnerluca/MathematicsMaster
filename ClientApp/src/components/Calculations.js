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

function CreateMultiplication({id}){
    let max = 9;
    //alert(toString(id));
    let [first, second] = createTwoRandomNumbers(max, max);
    let idC = "c"+id;
    let idI = "i"+id;
    return(
        <p id={idC}>{first} * {second} = <input id={idI} className='calInp'></input></p>
    )
}

function CreateDivision({id}){
    let maxf = 100;
    let maxs = 10;
    let idC = "c"+id;
    let idI = "i"+id;
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x % y === 0 && x/y < 10)
    return(
        <p id={idC}>{first} : {second} = <input id={idI} className='calInp'></input></p>
    )
}

function CreateSubtraction({id}){
    let maxf = 99;
    let maxs = 99;
    let idC = "c"+id;
    let idI = "i"+id;
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x >= y);
    return(
        <p id={idC}>{first} - {second} = <input id={idI} className='calInp'></input></p>
    )
}

function CreateAddition({id}){
    let maxf = 99;
    let maxs = 99;
    let idC = "c"+id;
    let idI = "i"+id;
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x+y < 100)
    return(
        <p id={idC}>{first} + {second} = <input id={idI} className='calInp'></input></p>
    )
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
            comps.push(<CreateSubtraction key={i} id={i}/>)
        }
    }
    else if(type === "3"){
        for(let i = 0; i < 100; i++){
            comps.push(<CreateMultiplication key={i} id={i}/>)
        }
    }
    else if(type == "4"){
        for(let i=0; i < 100; i++){
            comps.push(<CreateDivision key={i} id={i}/>)
        }
    }
    return <div>{comps}</div>

  }

function oldcheckCalculations(option){
    alert("Checking");
    for(let i = 0; i < 100; i++){
        let calcCo = document.getElementById("c"+i);
        let resultCo = document.getElementById("i"+i);

        if (calcCo && resultCo){
            let calc = calcCo.textContent;
            let txt = calc.splitText(" ");
            let firstNum = txt[0];
            let secondNum = txt[2];

            let resTxt = resultCo.textContent;
            let correct = false;
            alert(resTxt);
            alert(firstNum);
            alert(resTxt);
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
                alert("hurra correct")
                //change class of inp to correct
                resultCo.classList.add("correct");
            }
            else{
                //change class to false
                resultCo.classList.add("false");
            }
        }
    }
}

function checkCalculations(option){
    alert("checking");
    for(let i = 0; i < 100; i++){
        let calcCo = document.getElementById("c"+i);
        let resultCo = document.getElementById("i"+i);
        let text = calcCo.textContent;
        let txt = text.split(" ");
        let firstNum = txt[0];
        let secondŃum = txt[2];
        let result = resultCo.value;
        let correct = false;
        if (option == "1" && parseInt(firstNum)+parseInt(secondŃum) == result){
            correct = true;
        }
        else if(option == "2" && firstNum-secondŃum == result){
            correct = true;
        }
        else if(option == "3" && firstNum*secondŃum == result){
            correct = true;
        }
        else if(option == "4" && firstNum/secondŃum == result){
            correct = true;
        }
        if(result !== ""){
            if(correct){
                resultCo.classList.add("correct");
            }
            else{
                resultCo.classList.add("false");
            }
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
                <button onClick={checkCalculations.bind(this, option)}>Check</button>

                <select id="comType" onChange={this.selectionChange} value={option}>
                    <option value="1">Addition</option>
                    <option value="2">Subtraction</option>
                    <option value="3">Multiplication</option>
                    <option value="4">Division</option>
                </select>
                {CreateHundredCalculations(option)}
                <button onClick={checkCalculations.bind(this, option)}>Check</button>
            </div>
        );
    }
}