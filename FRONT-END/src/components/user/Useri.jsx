import React, { useState, useEffect } from 'react'
import { Card, Icon, Image, Button, Form, Transition } from 'semantic-ui-react'
// import matthew from '../../images/matthew.png';
import styled from "styled-components";
import Navbar from './navbar/Navbar';
import axios from 'axios';
import {selectUser} from '../../reducers/rootReducer'
import { useSelector } from "react-redux";

export const BoxContainer = styled.div`
margin-left:30%;
width:40%;
margin-top:3%;
display:flex;
`;



export default function UserCard() {
    const [active, setActive] = useState(true);
    const [emri, setEmri] = useState("");
    const [email, setEmail] = useState("");
    const [kompania, setKompania] = useState("");
    const [qyteti, setQyteti] = useState(0);
    const [user, setUser] = useState();
    const [qytetet, setQytetet] = useState([]);


    const useriFromRedux=useSelector(selectUser);
  
    var userIdd = useriFromRedux.userId;
    const userId = () => {
        localStorage.setItem("userId", userId)
    }
    const token = (response) => {
        const token = response.data.token;
        const refreshToken = response.data.refreshToken;
        localStorage.setItem("accessToken", token);
        localStorage.setItem("refreshToken", refreshToken);
    }

    //var token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZHJlbkBnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjhkNmZkMzdlLTE1M2EtNDMwMy04OWM0LWY0ZjNiNmVlNjc0NCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImRyZW5AZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXNlciIsImV4cCI6MTYyNTk1MTE2MCwiaXNzIjoiUGFydHNNYW5hZ2VtZW50QVBJIn0.nEbtYOyoS_urdaN9DXsZ7_Lq2EHHyEsz6eSkelh6yjRMiAddREwmwCheKQdkyNHflGVeH017GZpu_cYzrj6D5A";

    const config = {
        headers: {
            Authorization: 'Bearer ' + token
        }
    };

    const teDhenat = { emri, email, kompania, qytetet }

    const EditoUserin = async () => {

        await axios.put("http://localhost:5000/api/User/" + `${userIdd}`, config, teDhenat)

            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }
    useEffect(() => {

        axios.get('http://localhost:5000/api/User/current/' + `${userIdd}`).then(response => {
            //     const token = response.data.token;
            //     const refreshToken = response.data.refreshToken;
            //    // const userId = response.data.userId;
            //     localStorage.setItem("accessToken", token);
            //     localStorage.setItem("refreshToken", refreshToken);
            localStorage.setItem('emri', emri);
            localStorage.setItem('mbiemri', response.data.mbiemri);
            localStorage.setItem('kompania', response.data.kompania);
            // localStorage.setItem('userId',userId);
            setUser(response.data)
            console.log(user);
        });
    }, [user])



    useEffect(() => {

        axios.get('http://localhost:5000/api/Qyteti?shtetiId=1').then(response => {
            setQytetet(response.data);
            console.log(qytetet, "qyteti")
        });

    }, [])


    return (
        <BoxContainer>
            <Card>
                <Image src="" wrapped ui={false} />
                <Card.Content>
                    <Card.Header>
                        {localStorage.getItem('emri') && (
                            <div>
                                <p>{localStorage.getItem('emri')}</p>
                            </div>
                        )}
                    </Card.Header>
                    <Card.Meta>
                        <span className='date'>Joined in 2021</span>
                    </Card.Meta>
                    <Card.Description>
                        {localStorage.getItem('emri') && (
                            <div>
                                Emri: <p>{localStorage.getItem('emri')}</p>
                            </div>
                        )} eshte nje shites i autopjeseve.
                    </Card.Description>
                </Card.Content>
                <Card.Content extra>
                    <Icon name='user' />
                    {localStorage.getItem('emri') && (
                        <div>
                            Emri: <p>{userIdd.kompania}</p>
                        </div>
                    )}
                    <Button icon className="butoniEditit" onClick={() => setActive(!active)} color='blue'>
                        <Icon name='edit' />
                    </Button>
                </Card.Content>

            </Card>
            <Transition visible={!active} animation='scale' duration={500}>

                <Form className={active ? "forma hide" : "forma unhide"}>
                    <Form.Field>
                        <label>Emri :</label>
                        <input placeholder='Emri' onChange={(e) => setEmri(e.target.value)} value={emri} />
                    </Form.Field>
                    <Form.Field>
                        <label>Email :</label>
                        <input placeholder='Email' onChange={(e) => setEmail(e.target.value)} value={email} />
                    </Form.Field>
                    <Form.Field>
                        <label>Kompania :</label>
                        <input placeholder='Kompania' onChange={(e) => setKompania(e.target.value)} value={kompania} />
                    </Form.Field>
                    <Form.Field>
                        <select name="emriQytetit" onChange={(e => setQyteti(e.target.value))}>
                            {qytetet.map((e, key) => {
                                return <option key={key} value={e.qytetiId}>{e.emri}</option>;
                            })}
                        </select>
                    </Form.Field>
                    <Button color="blue" onClick={EditoUserin}>Ruaj</Button> <Button color="red" onClick={() => setActive(!active)} >Mbyll</Button>
                </Form>
            </Transition>

        </BoxContainer>



    );
}
