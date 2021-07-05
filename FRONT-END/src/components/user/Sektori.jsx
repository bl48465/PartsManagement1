import React, { useState, useEffect } from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Button from '@material-ui/core/Button';
import axios from 'axios'
import { Header, Icon, Modal, Input } from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css'
import { BoxContainer, Flexirimi } from './navbar/StyledComponents';
import  SearchBar  from './navbar/SearchBar';

export function SektoriTable() {

    const token = window.localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: 'Bearer ' + token}
        };
    
    const [data, setData] = useState('')
    const [sektori, setSektori] = useState([]);
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
            emri: ''
        }
    });
    const [AddModal, setAddModal] = useState({
        modal: {
            emri: '',
            open: false
        }
    });
    const [SearchField, setSearchField] = useState('');


    useEffect(() => {
        axios.get('http://localhost:5000/api/Sektori/user',config).then(response => {
            setSektori(response.data);
        });

    }, [sektori])

    const fshijSektorin = async () => {

        setModal({ open: false })
        axios.delete("http://localhost:5000/api/Sektori/"+modali.currentID, config)
            .then((response) => {
                console.log(response.data)
            })
            .catch((error) => {
                console.log(error);
            })

    }

    function handleChange(e) {
        setData(e.target.value);
        console.log(data);
    }

    const UpdateSektori = async () => {
        console.log(Editmodal.currentID);
        console.log(data);
        setEditModal({ open: false })
        axios.put("http://localhost:5000/api/Sektori/" + Editmodal.currentID,
            { sektoriID: Editmodal.currentID, emri: data }, config)
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }

    const ShtoSektor = async () => {

        setAddModal({ open: false })

        axios.post("http://localhost:5000/api/Sektori/",{ emri: data },config)
            .then((response) => {
                console.log(response.data)
            })
            .catch((error) => {
                console.log(error);
            })

    }

    return (

        <BoxContainer>
            <div style={{ margin: 30, padding: 0, width: 500 }}>
                <Flexirimi>
                    <div style={{ display: 'block', padding: 10, marginBottom: 1 }}>
                        <SearchBar
                            placeholder="Enter Name"
                            handleChange={e => setSearchField(e.target.value)} />
                    </div>
                    <div style={{ display: 'block', padding: 10 }}>
                        <Button className="butoni" variant="contained" color="secondary"
                            onClick={() => setAddModal({ open: true })}>
                            Shto nje Sektor
                        </Button>
                    </div>
                </Flexirimi>
            </div>
            <Table className="" aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell>SektoriID</TableCell>
                        <TableCell align="right">Emri Sektorit</TableCell>
                        <TableCell align="right">Manage</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {sektori.filter(rreshti => rreshti.emri.toLowerCase()
                        .includes(SearchField.toLowerCase())).map((row, key) => (
                            <TableRow key={row.sektoriId}>
                                <TableCell align="right">{row.sektoriId}</TableCell>
                                <TableCell align="right">{row.emri}</TableCell>
                                <TableCell align="right"> <Button variant="contained" color="primary"
                                    onClick={() =>
                                        setEditModal(
                                            { currentID: row.sektoriId, open: true, emri: row.emri })}>
                                    Perditeso
                                </Button>
                                    <Button variant="contained" color="secondary"
                                        onClick={() => setModal({ currentID: row.sektoriId, open: true })}>
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
                onClose={() => setModal({ open: false })}
                onOpen={() => setModal({ open: true })}
            >
                <Header icon='archive' content='Konfirmo Fshirjen!' />
                <Modal.Content>
                    <p>
                        Dëshironi te fshini Sektorin?
                    </p>
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={() => setModal({ open: false })}>
                        <Icon name='remove' /> Jo
                    </Button>
                    <Button color='green' onClick={fshijSektorin}>
                        <Icon name='checkmark' /> Po
                    </Button>
                </Modal.Actions>
            </Modal>
            <Modal
                closeIcon
                open={Editmodal.open}
                onClose={() => setEditModal({ open: false })}
                onOpen={() => setEditModal({ open: true })}
            >
                <Header icon='archive' content='Edito Te Dhenat!' />
                <Modal.Content>
                    <Input focus placeholder='Search...' defaultValue={Editmodal.emri}
                        onChange={handleChange} />
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={() => setEditModal({ open: false })}>
                        <Icon name='remove' /> Pishmon
                    </Button>
                    <Button color='green' onClick={UpdateSektori}>
                        <Icon name='checkmark' /> Përditëso
                    </Button>
                </Modal.Actions>
            </Modal>
            <Modal
                closeIcon
                open={AddModal.open}
                onClose={() => setAddModal({ open: false })}
                onOpen={() => setAddModal({ open: true })}
            >
                <Header icon='archive' content='Shto Sektor!' />
                <Modal.Content>
                    <Input focus placeholder='Emri Sektorit'
                        onChange={handleChange} />
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={() => setAddModal({ open: false })}>
                        <Icon name='remove' /> Pishmon
                    </Button>
                    <Button color='green' onClick={ShtoSektor}>
                        <Icon name='checkmark' /> Shto
                    </Button>
                </Modal.Actions>
            </Modal>
        </BoxContainer>
    );
}
