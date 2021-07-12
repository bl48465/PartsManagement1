import React, { useState, useEffect } from 'react'
import { Modal, Icon, Input, Button, Header } from 'semantic-ui-react'
// import matthew from '../../images/matthew.png';
import styled from "styled-components";
import axios from 'axios';
import { selectUser } from '../../reducers/rootReducer'
import { useSelector } from "react-redux";
import logo from '../../assets/logo/logo.png'
import { Select } from './navbar/StyledComponents';

export const BoxContainer = styled.div`
margin-left:21%;
width:50%;
height:40%;
margin-top:3%;
display:flex;
`;

export const Flex = styled.div`
display:flex;
flex-direction:row;
`;



export default function UserCard() {
    const [active, setActive] = useState(true);
    const [emri, setEmri] = useState("");
    const [email, setEmail] = useState("");
    const [mbiemri, setMbiemri] = useState("");
    const [qyteti, setQyteti] = useState(0);
    const [user, setUser] = useState([]);
    const [qytetet, setQytetet] = useState([]);
    const [deleteModal,setDeleteModal]=useState(false);
    const [Editmodal, setEditModal] = useState({
        modali: {
            currentID: 0,
            open: false,
            emri: '',
            mbiemri: '',
            email: '',
            qyteti: 0
        }
    });


    const useriFromRedux = useSelector(selectUser);
    var userIdd = useriFromRedux.userId;


    const config = {
        headers: {
            Authorization: 'Bearer ' + useriFromRedux.token
        }
    };

    const teDhenat = { emri, mbiemri, email, qyteti }

    const EditoUserin = async () => {

        await axios.put("http://localhost:5000/api/User/" + userIdd, config, teDhenat)

            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }
    useEffect(() => {

        fetchData();


    }, [user])

    const fetchData = async () => {
        axios.get('http://localhost:5000/api/User/current/' + userIdd, config).then(response => {
            setUser(response.data);

        });

        axios.get('http://localhost:5000/api/Qyteti?shtetiId=1').then(response => {
            setQytetet(response.data);

        });

    }


    return (
        <BoxContainer>
            <Flex>
                <img src={logo} className="picu" width="35%" />
                <div className="myInfo-box">
                    <h2 className="titulli">{'Ckemi, ' + useriFromRedux.emri}</h2>
                    <hr></hr>
                    <div className="data">
                        <h3>Te dhenat tuaja:</h3>
                        <p>{'Emri: ' + useriFromRedux.emri}</p>
                        <p>{'Email: ' + useriFromRedux.email}</p>
                        <p>{'Roli: ' + useriFromRedux.roli}</p>
                        {/* <p>{'Kompania: ' + user[0].kompania}</p> */}
                        <Flex>
                        <Button onClick={() =>
                            setEditModal(
                                { currentID: user[0].userId, open: true, emri: user[0].emri, mbiemri: user[0].mbiemri, email: user[0].email, qytetiId: user[0].qytetiId })}>Edito t'dhenat</Button>

                        <Button onClick={() =>setDeleteModal(true) }>Edito Fjalekalimin</Button>
                        </Flex>
                    </div>
                    
                </div>
            </Flex>
            <Modal
                closeIcon
                open={Editmodal.open}
                size='mini'
                onClose={() => setEditModal({ open: false })}
                onOpen={() => setEditModal({ open: true })}
            >
                <Header icon='archive' content='Edito të dhënat' />
                <Modal.Content>
                    <Input focus placeholder='Emri' name="emri" defaultValue={Editmodal.emri}
                        onChange={(e) => setEmri(e.target.value)} />
                    <Input focus placeholder='Mbiemri' name="mbiemri" defaultValue={Editmodal.mbiemri}
                        onChange={(e) => setMbiemri(e.target.value)} />
                    <Input focus placeholder='Email' name="email" defaultValue={Editmodal.email}
                        onChange={(e) => setEmail(e.target.value)} />

                    <Select onChange={(e) => setQyteti(e.target.value)} name="qytetiId" defaultValue={Editmodal.qyteti}>
                        {qytetet.map((e, key) => {
                            return <option key={key} value={e.qytetiId}>{e.emri}</option>;
                        })}
                    </Select>


                </Modal.Content>
                <Modal.Actions>
                    <Button color='black' onClick={() => setEditModal({ open: false })}>
                        <Icon name='remove' />Pishmon
                    </Button>
                    <Button color='green' onClick={EditoUserin}>
                        <Icon name='checkmark' /> Përditëso
                    </Button>
                </Modal.Actions>
            </Modal>


            
            {/* Modali per password */}

            <Modal
                closeIcon
                open={deleteModal}
                size='mini'
                onClose={() => setDeleteModal(false )}
                onOpen={() => setDeleteModal(true)}
            >
                <Header icon='archive' content='Ndrysho Fjalekalimin' />
                <Modal.Content>
                    <Input focus placeholder='Fjalekalimi i Tanishem' name="currentPassword" defaultValue={'test'}
                        onChange={(e) => setEmri(e.target.value)} />
                    <Input focus placeholder='Fjalekalimi i ri' name="newPassword" defaultValue={'test'}
                        onChange={(e) => setMbiemri(e.target.value)} />
                </Modal.Content>
                <Modal.Actions>
                    <Button color='black' onClick={() => setDeleteModal(false)}>
                        <Icon name='remove' />Pishmon
                    </Button>
                    <Button color='green' onClick={EditoUserin}>
                        <Icon name='checkmark' /> Përditëso
                    </Button>
                </Modal.Actions>
            </Modal>
        </BoxContainer>



    );
}
