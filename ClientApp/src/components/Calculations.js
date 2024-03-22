import React, { Component } from 'react';



function createTwoRandomNumbers(maxfirst, maxsecond, condition = () => true){
    //maxTrys does stop the condition lambda, if it is broken
    let maxTrys = 100;
    let i = 0;

    while (i < maxTrys)
    {
        //floor is rounding down, so that there will be a 'integer' value
        //the method in the bracket is kind of Random.Next in C# 
        let first = Math.floor(Math.random() * maxfirst + 1);
        let second = Math.floor(Math.random() * maxsecond + 1);
        if (condition(first, second))
        {
            return [first, second];
        }
        i++;
    }
    //if it fails it returns [0, 0]
    return [0, 0];
}


function CreateMultiplication({ id })
{
    let max = 9;
    let [first, second] = createTwoRandomNumbers(max, max);
    //id for paragraph of calculation
    let idC = "c" + id;
    //id for input of calculation
    let idI = "i"+id; 
    return (
        //HTML Code it creates a line for the calculation sheet and then controlls if the input of the user is the same
        <p id={idC} className='calc'>{first} * {second} = <input id={idI} className='calInp'></input></p>
    )
}


function CreateDivision({ id })
{
    let maxf = 100;
    let maxs = 10;
    let idC = "c"+id;
    let idI = "i" + id;
    //creates 2 random numbers | the anomyus function looks if the numbers have 0 rest and that one number divided is smaller than 10
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x % y === 0 && x/y < 10)
    return(
        <p id={idC} className='calc'>{first} : {second} = <input id={idI} className='calInp'></input></p>
    )
}


function CreateSubtraction({ id })
{
    let maxf = 99;
    let maxs = 99;
    let idC = "c"+id;
    let idI = "i" + id;
    //this anonymus function does look that x is greater than y, since otherwise the result would be negative
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x >= y);
    return(
        <p id={idC} className='calc'>{first} - {second} = <input id={idI} className='calInp'></input></p>
    )
}


function CreateAddition({ id })
{
    let maxf = 99;
    let maxs = 99;
    let idC = "c"+id;
    let idI = "i" + id;
    //this anonymus function looks that the additet numbers are under 100 so that they are only 99 at max value 
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x+y < 100)
    return(
        <p id={idC} className='calc'>{first} + {second} = <input id={idI} className='calInp'></input></p>
    )
}


function CreateTwentyFiveCalculations(type)
{
    let components = [];
    if (type === "1")
    {
        for (let i = 0; i < 25; i++)
        {
            //List.Add in C# | programme creates key ... automaticly
            components.push(<CreateAddition key={i} id={i}/>)
        }
    }
    else if (type === "2")
    {
        for (let i = 0; i < 100; i++)
        {
            //List.Add in C# | programme creates key ...  automaticly
            components.push(<CreateSubtraction key={i} id={i}/>)
        }
    }
    else if (type === "3")
    {
        for (let i = 0; i < 100; i++)
        {
            //List.Add in C# | programme creates key ...  automaticly
            components.push(<CreateMultiplication key={i} id={i}/>)
        }
    }
    else if (type === "4")
    {
        for (let i = 0; i < 100; i++)
        {
            //List.Add in C# | programme creates key ...  automaticly
            components.push(<CreateDivision key={i} id={i}/>)
        }
    }
    return <div className='TwentyFiveCalcs'>{components}</div>
  }


function checkCalculations(option)
{
    for (let i = 0; i < 100; i++)
    {
        //you get an elemend with your id
        let calcCo = document.getElementById("c"+i);
        let resultCo = document.getElementById("i"+i);
        if (calcCo !== null)
        {
            //.textContent gets the text of the selected item
            let text = calcCo.textContent;
            let txt = text.split(" ");
            let firstNum = txt[0];
            let secondNum = txt[2];
            //.value looks at the result of the calculation 
            let result = resultCo.value;
            let correct = false;
            if (option === "1" && parseInt(firstNum) + parseInt(secondNum) === result)
            {
                correct = true;
            }
            else if (option === "2" && firstNum - secondNum === result)
            {
                correct = true;
            }
            else if (option === "3" && firstNum * secondNum === result)
            {
                correct = true;
            }
            else if (option === "4" && firstNum / secondNum === result)
            {
                correct = true;
            }
            if (result !== "")
            {
                if (correct)
                {
                    resultCo.classList.add("correct");
                }
                else
                {
                    resultCo.classList.add("false");
                }
            }
        }
    }
}


function getCalculationsType(option){
    if(option === 1){
        return "a";
    }
    else if(option === 2){
        return "s";
    }
    else if(option === 3){
        return "m";
    }
    else if(option === 4){
        return "d";
    }
}


function download(option){
    const opt = "?type="+getCalculationsType(option);
    fetch('calculation'+opt)
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
};

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
                <button className='btn btn-primary' onClick={checkCalculations.bind(option)}>Check</button>

                <select className="selectpicker form-control border-0 mb-1 px-4 py-4 rounded shadow" id="comType" onChange={this.selectionChange} value={option}>
                    <option value="1">Addition</option>
                    <option value="2">Subtraction</option>
                    <option value="3">Multiplication</option>
                    <option value="4">Division</option>
                </select>
                <div className='container'>
                    <div className='column'>
                        {CreateTwentyFiveCalculations(option)}
                    </div>
                    <div className='column'>
                        {CreateTwentyFiveCalculations(option)}
                    </div>
                    <div className='column'>
                        {CreateTwentyFiveCalculations(option)}
                    </div>
                    <div className='column'>
                        {CreateTwentyFiveCalculations(option)}
                    </div>
                </div>
                <button className="btn btn-primary" onClick={checkCalculations.bind(this, option)}>Check</button>
            </div>
        );
    }
}