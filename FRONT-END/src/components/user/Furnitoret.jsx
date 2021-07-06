import React, { useState, useEffect } from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableRow from '@material-ui/core/TableRow';
import axios from 'axios'
import { Header, Icon, Modal, Input, Button } from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css'
import { BoxContainer, Flexirimi, MainDiv, TableHead , TableText , RowText } from './navbar/StyledComponents';

import { AddButton } from '../button/add'
import { UpdateButton } from '../button/update'
import { DeleteButton } from '../button/delButton'
import { IconContext } from 'react-icons';
import { SearchBar }  from './navbar/SearchBar';


export  function FurnitoriTable() {
    var token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYmxlcmltQGV4YW1wbGUuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiJiYWEwZWJmNi1lZGFjLTQxYjMtOTRiMS04NjRmMzM3MzE3NjUiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJibGVyaW1AZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNjI1NDEyMTQ1LCJpc3MiOiJQYXJ0c01hbmFnZW1lbnRBUEkifQ.iZfbepc_1eYBZ5i9Q-RCzjWWUQiLP5TCtAW2GSDFWAgVudYiALmJpmiD_5TjtiynmfGh9v2YoyYBIG4Cy6lzpA";
    var userId = "baa0ebf6-edac-41b3-94b1-864f33731765";

    const config = {
        headers: {
            Authorization: 'Bearer ' + token
        }
    };

    const [data, setData] = useState("");
    const [SearchField, setSearchField] = useState('');
    const [furnitorii, setfurnitoret] = useState([]);
    const [modali, setModal] = useState({
        modal: {
            currentID: 0,
            open: false,
        }
    });

    const [Editmodal, setEditModal] = useState({
        modali: {
            currentID: 0,
            open: false,
            emriFurnitorit: ''
        }
    });
    const [AddModal, setAddModal] = useState({
        modal: {
            emri: '',
            open: false,
        }
    });





    useEffect(() => {
        axios.get('http://localhost:5000/api/Furnitori/user', config).then(response => {
            setfurnitoret(response.data);
            console.log(furnitorii + "kujebe");
            console.log(response.data);
        });

    }, [])

    const removeFurnitor = async () => {

        setModal({ open: false })
        axios.delete("http://localhost:5000/api/Furnitori/" + modali.currentID, config)
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }

    function handleChange(e) {
        setData(e.target.value);
        console.log(data);
    }

    const updateFurnitor = async () => {
        console.log(Editmodal.currentID);
        console.log(data);
        setEditModal({ open: false })
        axios.put("http://localhost:5000/api/Furnitori/" + Editmodal.currentID, { furnitoriID: Editmodal.currentID, emriFurnitorit: data }, config)
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }

    const ShtoFurnitor = async () => {

        setAddModal({ open: false })
        axios.post("http://localhost:5000/api/Furnitori", { emriFurnitorit: data }, config)
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }



    return (
        <IconContext.Provider value={{ color: 'white' , size: '2%'}}>
        <BoxContainer>
        <MainDiv>
                <Flexirimi>
                        <AddButton onClick={() => setAddModal({ open: true })}>
                        <Icon name='add'/>
                        Shto furnitor
                        </AddButton>
                        <div style={{ display: 'block', padding: 10, marginBottom: 1 }}>
                        <SearchBar 
                            placeholder="Enter Name" 
                            handleChange={e => setSearchField(e.target.value)} />
                    </div>
                </Flexirimi>
        </MainDiv>

            <Table className="tabelaa" aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell fontSize="large" align="center"><TableText>FurnitoriID</TableText></TableCell>
                        <TableCell fontSize="large" align="center"><TableText>Emri Furnitorit</TableText></TableCell>
                        <TableCell fontSize="large" align="center"><TableText>Menaxho</TableText></TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {furnitorii
                        .filter(rreshti => rreshti.emriFurnitorit.toLowerCase()
                            .includes(SearchField.toLowerCase())).map((row, key) => (
                                <TableRow key={row.furnitoriID}>
                                    <TableCell align="right"><RowText>{row.furnitoriID}</RowText></TableCell>
                                    <TableCell align="right"><RowText>{row.emriFurnitorit}</RowText></TableCell>
                                    <TableCell align="right"> 
                                    <UpdateButton 
                                        onClick={() =>
                                            setEditModal(
                                            { currentID: row.furnitoriID, open: true, emriFurnitorit: row.emriFurnitorit })}>
                                            <Icon name='history'/>
                                            Përditëso
                                    </UpdateButton>
                                        <DeleteButton
                                            onClick={() => setModal({ currentID: row.furnitoriID, open: true })}>
                                            <Icon name='delete'/>
                                            Fshij
                                        </DeleteButton>
                                    </TableCell>

                                </TableRow>
                            ))}
                </TableBody>
            </Table>

            {/* Modali per Delete */}

            <Modal
                closeIcon
                open={modali.open}
                onClose={() => setModal({ open: false })}
                onOpen={() => setModal({ open: true })}
            >
                <Header icon='archive' content='Konfirmo Fshierjen!' />
                <Modal.Content>
                    <p>
                        Dëshironi të fshini furnitorin?
                    </p>
                </Modal.Content>
                <Modal.Actions>
                    <Button color='black' onClick={() => setModal({ open: false })}>
                        <Icon name='remove' /> Pishmon?
                    </Button>
                    <Button color='green' onClick={removeFurnitor}>
                        <Icon name='checkmark' /> Po
                    </Button>
                </Modal.Actions>
            </Modal>

            {/* Modali per Edit */}

            <Modal
                closeIcon
                open={Editmodal.open}
                onClose={() => setEditModal({ open: false })}
                onOpen={() => setEditModal({ open: true })}
            >
                <Header icon='archive' content='Edito Te Dhenat!' />
                <Modal.Content>
                    <Input focus placeholder='Search...' defaultValue={Editmodal.emriFurnitorit}
                        onChange={handleChange} />
                </Modal.Content>
                <Modal.Actions>
                    <Button color='black' onClick={() => setEditModal({ open: false })}>
                        <Icon name='remove' /> Pishmon
                    </Button>
                    <Button color='green' onClick={updateFurnitor}>
                        <Icon name='checkmark' /> Përditëso
                    </Button>
                </Modal.Actions>
            </Modal>

            {/* Modali per Add */}
            <Modal
                closeIcon
                open={AddModal.open}
                onClose={() => setAddModal({ open: false })}
                onOpen={() => setAddModal({ open: true })}
            >
                <Header icon='archive' content='ShtoFurnitor!' />
                <Modal.Content>
                    <Input focus placeholder='Emri Furnitorit...'
                        onChange={handleChange} />
                </Modal.Content>
                <Modal.Actions>
                    <Button color='black' onClick={() => setAddModal({ open: false })}>
                        <Icon name='remove' /> Pishmon
                    </Button>
                    <Button color='green' onClick={ShtoFurnitor}>
                        <Icon name='checkmark' /> Shto
                    </Button>
                </Modal.Actions>
            </Modal>
        </BoxContainer>
        </IconContext.Provider> 
    );
}