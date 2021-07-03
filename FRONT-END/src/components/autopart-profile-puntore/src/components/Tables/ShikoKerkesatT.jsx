import React, { useState, useEffect } from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import styled from "styled-components";
import Button from '@material-ui/core/Button';
import axios from 'axios'
import { Header, Icon, Modal,Input } from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css'


export const BoxContainer = styled.div`
  margin-top:10px !important;
  width: 80%;
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-left:10%;

`;

export const ButtonContainer = styled.div`
  width: 50px;
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-left:0%;
`;


export default function ShikoKerkesatTable(){
    const[kerkesa,setKerkesa]=useState([]);
    const [modali, setModal] = useState({
        modal:{
            currentID:0,
            open:false,
        }
    });

    useEffect(()=>{
        axios.get('http://localhost:5000/api/Kerkesa/').then(response=>{
            setKerkesa(response.data);
        });
        
    },[kerkesa])

    const removeKerkesa=async()=>{
        setModal({open:false})
        axios.delete("http://localhost:5000/api/Kerkesa/"+modali.currentID,{withCredentials:true})
        .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })
    }

    return(
        <BoxContainer>
            <Table className="tabelaa" aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell>KerkesaID</TableCell>
                        <TableCell align="right">Emri Mbiemri</TableCell>
                        <TableCell align="right">Email</TableCell>
                        <TableCell align="right">Marka</TableCell>
                        <TableCell align="right">Modeli</TableCell>
                        <TableCell align="right">Mbishkrimi</TableCell>
                        <TableCell align="right">Manage</TableCell>
                    </TableRow>
                </TableHead>
                
                <TableBody>
                
                    {kerkesa.map((row)=>(
                        
                        <TableRow key={row.kekresaID}>
                            
                            <TableCell align="right">{row.kekresaID}</TableCell>
                            <TableCell align="right">{row.emriMbiemri}</TableCell>
                            <TableCell align="right">{row.marka}</TableCell>
                            <TableCell align="right">{row.modeli}</TableCell>
                            <TableCell align="right">{row.mbishkrimi}</TableCell>
                            <TableCell align="right">
                                <Button variant="green" color="secondary" 
                                onClick={()=>setModal({currentId:row.KekresaID, open:true})}>
                                    Fshij
                                </Button>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>

            <Modal
                closeIcon
                open={modali.open}
                onClose={() => setModal({open:false})}
                onOpen={() => setModal({open:true})}
            >
                <Header icon='archive' content='Konfirmo Fshierjen!' />
                <Modal.Content>
                    <p>
                        Deshironi te fshini Userin?
                    </p>
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={() => setModal({open:false})}>
                        <Icon name='remove' /> Pishmon?
                    </Button>                   
                    <Button color='green' onClick={removeKerkesa}>
                        <Icon name='checkmark' /> Yes
                    </Button>
                </Modal.Actions>
            </Modal>

        </BoxContainer>
    )
}