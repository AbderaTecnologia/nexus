import {
    PiHouseLineDuotone,
    PiArrowsInDuotone,
    PiBookOpenUserDuotone,
    PiBookBookmarkDuotone,
    PiAcornDuotone,
    PiBagSimpleDuotone,
    PiLightbulbDuotone,
    PiPencilSimpleLineDuotone,
    PiUserCircleDuotone,
    PiUserListDuotone,
    PiUserPlusDuotone,
    PiUsersDuotone,
} from 'react-icons/pi'
import { TiBusinessCard } from "react-icons/ti";
import { MdAppRegistration } from "react-icons/md";
import type { JSX } from 'react'

export type NavigationIcons = Record<string, JSX.Element>

const navigationIcon: NavigationIcons = {
    home: <PiHouseLineDuotone />,
    singleMenu: <PiAcornDuotone />,
    collapseMenu: <PiArrowsInDuotone />,
    groupSingleMenu: <PiBookOpenUserDuotone />,
    groupCollapseMenu: <PiBookBookmarkDuotone />,
    groupMenu: <PiBagSimpleDuotone />,
    folha: <TiBusinessCard />,
    register: <MdAppRegistration />,
    concepts: <PiLightbulbDuotone />,
    customers: <PiUsersDuotone />,
    customerList: <PiUserListDuotone />,
    customerEdit: <PiPencilSimpleLineDuotone />,
    customerCreate: <PiUserPlusDuotone />,
    customerDetails: <PiUserCircleDuotone />,
}

export default navigationIcon
