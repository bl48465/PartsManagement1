import React from 'react'
import Dankmemes from './Chart'
import FeaturedInfo from './FeaturedInfo'
import Navbar from './navbar/Navbar'
import { BoxContainer } from './navbar/StyledComponents'

export const HomeUser = () => {
    return (
        <div>

            <Navbar />
            <BoxContainer>
                <Dankmemes />
            </BoxContainer>
        </div>
    )
}
