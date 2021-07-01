import React, { useState, useEffect } from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Button from '@material-ui/core/Button';
import axios from 'axios'
import { Header, Icon, Modal,Input,Transition } from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css'
import SearchBar from '../SearchBar';
import {BoxContainer,Flexirimi} from '../StyledComponents';


export default function FurnitoriTable() {
    const[data,setData]=useState("");
    const[SearchField,setSearchField]=useState('');
    const[furnitorii,setfurnitoret] = useState([]);
    const [modali, setModal] = useState({
        modal:{
            currentID:0,
            open:false,
        }
    });

    const [Editmodal, setEditModal] = useState({
        modali:{
            currentID:0,
            open:false,
            emriFurnitorit:''
        }
    });
    const [AddModal, setAddModal] = useState({
        modal:{
            emri:'',
            open:false,
        }
    });

    



    useEffect(() => {
        axios.get('http://localhost:5000/api/Furnitoris').then(response => {
            setfurnitoret(response.data);
        });

    }, [furnitorii])

    const removeFurnitor = async () => {

        setModal({open:false})
        axios.delete("http://localhost:5000/api/Furnitoris/" + modali.currentID, { withCredentials: true })
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }
    
    function handleChange(e){
        setData(e.target.value);
        console.log(data);
    }
    
    const updateFurnitor = async () => {
        console.log(Editmodal.currentID);
        console.log(data);
        setEditModal({open:false})
        axios.put("http://localhost:5000/api/Furnitoris/" + Editmodal.currentID, {furnitoriID:Editmodal.currentID,emriFurnitorit:data}, { withCredentials: true })
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }

    const ShtoFurnitor = async () => {
     
        setAddModal({open:false})
        axios.post("http://localhost:5000/api/Furnitoris", {emriFurnitorit:data}, { withCredentials: true })
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }


    //Tabela

    return (
        <BoxContainer>
            <div style={{margin:30,padding:0 , width:500}}>
            <Flexirimi>
            <div style={{display:'block', padding:10, marginBottom:1}}>
            <SearchBar placeholder="Enter Name" handleChange={e=>setSearchField(e.target.value)} />
            </div>
            <div style={{display:'block', padding:10}}>
            <Button variant="contained" color="secondary"
            onClick={() => setAddModal({open:true})}>
            Shto nje Furnitor
            </Button> 
            </div>
            </Flexirimi>
            </div>
            <Table className="tabelaa" aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell>FurnitoriID</TableCell>
                        <TableCell align="right">Emri Furnitorit</TableCell>
                        <TableCell align="right">Manage</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                {furnitorii
                .filter(rreshti=>rreshti.emriFurnitorit.toLowerCase()
                .includes(SearchField.toLowerCase())).map((row,key)=>(
                    <TableRow key={row.furnitoriID}>
                        <TableCell align="right">{row.furnitoriID}</TableCell>
                        <TableCell align="right">{row.emriFurnitorit}</TableCell>
                        <TableCell align="right"> <Button variant="contained" color="primary" 
                        onClick={() => 
                        setEditModal({currentID:row.furnitoriID,open:true,emriFurnitorit:row.emriFurnitorit})}>
                            Perditeso
                        </Button>
                            <Button variant="contained" color="secondary"
                            onClick={() => setModal({currentID:row.furnitoriID,open:true})}>
                                Fshij
                            </Button>
                        </TableCell>
                    
                    </TableRow>
                ))}
                </TableBody>
            </Table>
            
            {/* Modali per Delete */}

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
                    <Button color='green' onClick={removeFurnitor}>
                        <Icon name='checkmark' /> Yes
                    </Button>
                </Modal.Actions>
            </Modal>

            {/* Modali per Edit */}
            
            <Modal
                closeIcon
                open={Editmodal.open}
                onClose={() => setEditModal({open:false})}
                onOpen={() => setEditModal({open:true})}
            >
                <Header icon='archive' content='Edito Te Dhenat!' />
                <Modal.Content>
                <Input focus placeholder='Search...' defaultValue={Editmodal.emriFurnitorit} 
                onChange={handleChange} />
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={() => setEditModal({open:false})}>
                        <Icon name='remove' /> Pishmon
                    </Button>
                    <Button color='green' onClick={updateFurnitor}>
                        <Icon name='checkmark' /> Perditeso
                    </Button>
                </Modal.Actions>
            </Modal>

               {/* Modali per Add */}
            <Modal
                closeIcon
                open={AddModal.open}
                onClose={() => setAddModal({open:false})}
                onOpen={() => setAddModal({open:true})}
            >
                <Header icon='archive' content='ShtoFurnitor!' />
                <Modal.Content>
                <Input focus placeholder='Emri Furnitorit...' 
                onChange={handleChange} />
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={() => setAddModal({open:false})}>
                        <Icon name='remove' /> Pishmon
                    </Button>
                    <Button color='green' onClick={ShtoFurnitor}>
                        <Icon name='checkmark' /> Shto
                    </Button>
                </Modal.Actions>
            </Modal>
        </BoxContainer>
    );
}