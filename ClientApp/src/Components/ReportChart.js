import React from 'react'
import { Line } from 'react-chartjs-2'


export default function ReportChart(props) {
  const reportValues = props.data;   
  let incomesLabels = [];
  let incomesAmount = [];  
  let expensesAmount = [];  

  reportValues.forEach(element => {
      let names =`${element.incomeName}--${element.expenseName}`;    //''+ element.incomeName +' ' + '-- '+ element.expenseName +''
      incomesLabels.push(names)
      incomesAmount.push(element.incomeAmount)  
      expensesAmount.push(element.expenseAmount)    
  });
  
  const data = {
    labels: incomesLabels,
    datasets: [
      {
        label: "Ingreso",
        data: incomesAmount,
        fill: true,
        backgroundColor: "rgba(75,192,192,0.2)",
        borderColor: "rgba(75,192,192,1)"      
      },
      {
        label: "Gasto",
        data: expensesAmount,
        fill: false,
        borderColor: "#742774"
      },
    ]
  }
  return (
    <div style={{ width: '90%', height: '90%', margin: 'auto'}}>
      <Line data={data} options={{ maintainAspectRatio: false }} />
    </div>
  )
}