import React, { useState, useEffect } from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Button from '@material-ui/core/Button';
import axios from 'axios'
import { Header, Icon, Modal,Input } from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css'
import {BoxContainer,Flexirimi} from '../StyledComponents';
import SearchBar from '../SearchBar';


export default function PorosiaTable() {
    const [data, setData] = useState({
        dataInfo:{
            emri:'',
            sasia:0
        }
    });
    const[porosia,setPorosia] = useState([]);
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
            emriPorosise:'',
            sasia:0
        }
    });
    const [AddModal, setAddModal] = useState({
        modal:{
            emri:'',
            sasia:null,
            open:false,
        }
    });
    const[SearchField,setSearchField]=useState('');




    useEffect(() => {
        axios.get('http://localhost:5000/api/Porosia',{ withCredentials: true }).then(response => {
            console.log(response);
            setPorosia(response.data);
        });

    }, [porosia])

    const fshijPorosine = async () => {

        setModal({open:false})
        axios.delete("http://localhost:5000/api/Porosia/" + modali.currentID, { withCredentials: true })
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
    
    const UpdatePorosia = async () => {
        console.log(Editmodal.currentID);
        console.log(data);
        setEditModal({open:false})
        axios.put("http://localhost:5000/api/Porosia/" + Editmodal.currentID, 
        {porosiaID:Editmodal.currentID,emri:data[0],sasia:data[1]}, { withCredentials: true })
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }

    const ShtoPorosi = async () => {
     
        setAddModal({open:false})
        axios.post("http://localhost:5000/api/Porosia/1", {emri:data[0],sasia:data[1]}, { withCredentials: true })
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }


    // const classes = useStyles();

    return (
        <BoxContainer>
              <div style={{margin:30,padding:0 , width:500}}>
            <Flexirimi>
            <div style={{display:'block', padding:10, marginBottom:1}}>
            <SearchBar placeholder="Enter Name" handleChange={e=>setSearchField(e.target.value)} />
           </div>
           <div style={{display:'block', padding:10}}>
            <Button  className="butoni" variant="contained" color="secondary"
            onClick={() => setAddModal({open:true})}>
            Shto nje Porosi
            </Button>
            </div>
            </Flexirimi>
            </div>
            <Table className="" aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell>PorosiaID</TableCell>
                        <TableCell align="right">Emri Porosise</TableCell>
                        <TableCell align="right">Sasia</TableCell>
                        <TableCell align="right">Manage</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                {porosia.filter(rreshti=>rreshti.emriFurnitorit.toLowerCase()
                .includes(SearchField.toLowerCase())).map((row,key)=>(
                    <TableRow key={row.porosiaID}>
                        <TableCell align="right">{row.porosiaID}</TableCell>
                        <TableCell align="right">{row.emri}</TableCell>
                        <TableCell align="right">{row.sasia}</TableCell>
                        <TableCell align="right"> <Button variant="contained" color="primary" 
                        onClick={() => 
                        setEditModal(
                            {currentID:row.porosiaID,open:true,emriPorosise:row.emri,sasia:row.sasia})}>
                            Perditeso
                        </Button>
                            <Button variant="contained" color="secondary"
                            onClick={() => setModal({currentID:row.PorosiaID,open:true})}>
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
                    Deshironi te fshini porosine?
                    </p>
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={() => setModal({open:false})}>
                        <Icon name='remove' /> No
                    </Button>                   
                    <Button color='green' onClick={fshijPorosine}>
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
                <Input focus placeholder='Search...' defaultValue={Editmodal.emriPorosise} 
                onChange={handleChange} />
                  <Input focus placeholder='Search...' defaultValue={Editmodal.sasia} 
                onChange={handleChange} />
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={() => setEditModal({open:false})}>
                        <Icon name='remove' /> Pishmon
                    </Button>
                    <Button color='green' onClick={UpdatePorosia}>
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
                <Header icon='archive' content='Shto Porosi!' />
                <Modal.Content>
                <Input focus placeholder='Emri Porosise' 
                onChange={handleChange} />
                 <Input focus placeholder='Sasia' 
                onChange={handleChange} />
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={() => setAddModal({open:false})}>
                        <Icon name='remove' /> Pishmon
                    </Button>
                    <Button color='green' onClick={ShtoPorosi}>
                        <Icon name='checkmark' /> Shto
                    </Button>
                </Modal.Actions>
            </Modal>
        </BoxContainer>
    );
}