import React, { Component } from 'react';

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

function CreateAdditino(){
    let maxf = 99;
    let maxs = 99;
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x+y < 100)
    return <p>{first} + {second} = <input></input></p>
}

function CreateHundredCalculations() {
    const comps = [];
    const type = getNumberInCombobox();
    if(type == "1"){
        for(let i = 0; i < 100; i++){
            comps.push(<CreateAdditino key={i}/>)
        }
    }
    else if(type == "2"){
        for(let i = 0; i < 100; i++){
            comps.push(<CreateSubtraction key={i}/>)
        }
    }
    else if(type === "3"){
        for(let i = 0; i < 100; i++){
            comps.push(<CreateMultiplication key={i}/>)
        }
    }
    else if(type == "4"){
        for(let i=0; i < 100; i++){
            comps.push(<CreateDivision key={i}/>)
        }
    }
    return <div>{comps}</div>

  }

function getNumberInCombobox(){
        return "1";
    
  }


export class CreateCalculationsForPrimarySchool extends Component {
    render() {
        return (
            <div>
                <h1>Calculations</h1>
                <select id="comType" onChange={CreateHundredCalculations}>
                    <option value="1">Addition</option>
                    <option value="2">Subtraction</option>
                    <option value="3">Multiplication</option>
                    <option value="4">Division</option>
                </select>
            </div>
      
        );
    }
}
