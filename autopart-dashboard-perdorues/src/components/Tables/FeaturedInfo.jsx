import React,{useState,useEffect} from 'react'
import "./featuredInfo.css";
import { Centirimi } from "../StyledComponents";
import axios from 'axios';
import { Icon, Image, Statistic } from 'semantic-ui-react';
import furnitori from '../../images/furnitori.jpg';



export default function FeaturedInfo() {
  const[furnita,setFurnita]=useState([]);
  const[count,setCount]=useState(0);
  
  useEffect(() => {
    axios.get('http://localhost:5000/api/Furnitoris').then(response => {
        setFurnita(response.data);
        setCount(furnita.length);
    });

}, [furnita])



  return (
    <Centirimi>
  
    <div className="featured">
      <div className="featuredItem">
  
    <Statistic>
    <Statistic.Value>
        <Image src={furnitori} inline circular />
        {count}
      </Statistic.Value>
      <Statistic.Label>Furnitor Te Regjistruar</Statistic.Label>
    </Statistic>
      </div>
      
      <div className="featuredItem">
      <Statistic>
      <Statistic.Value>
        <Icon name='chart bar' size='small' />5
      </Statistic.Value>
      <Statistic.Label>Nr i Produkteve</Statistic.Label>
    </Statistic>
        </div>
        </div>
    </Centirimi>
  );
}
