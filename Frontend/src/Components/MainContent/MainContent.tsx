import { Card, Dropdown, Option } from '@fluentui/react-components'
import React, { useState } from 'react'
import { SideMenu } from '../SideMenu/SideMenu'
import { IAreaChartProps, ChartHoverCard, DataVizPalette, getColorFromToken, DonutChart, IChartProps } from '@fluentui/react-charting';
import { IMenu } from '../SideMenu/Menu/MenuSection';
import './mainContent.css'
import { useMenu } from '../../Infrastructure/Contexts/MenuContext';
import { EftRealtimeDashboard } from '../../Views/EftRealtimeDashboard/EftRealtimeDashboard';
const menu: IMenu[] = [{
  name: 'Main Navigation', subMenu: [{
    name: 'AVS batch', subMenu: [
      {
        name: 'Dashboard'
      },
      {
        name: 'File History'
      },
      {
        name: 'Transaction History'
      }
    ]
  }, {
    name: 'DebiCheck', subMenu: [
      {
        name: 'Dashboard'
      },
      {
        name: 'File History'
      },
      {
        name: 'Transaction History'
      }
    ]
  }, {
    name: 'EFT Batch', subMenu: [
      {
        name: 'Dashboard'
      },
      {
        name: 'File History'
      },
      {
        name: 'Transaction History'
      }
    ]
  }, {
    name: 'EFT Realtime', subMenu: [
      {
        name: 'Dashboard'
      },
      {
        name: 'File History'
      },
      {
        name: 'Transaction History'
      }
    ]
  }, {
    name: 'Mandate Management', subMenu: [
      {
        name: 'Dashboard'
      },
      {
        name: 'File History'
      },
      {
        name: 'Transaction History'
      }
    ]
  }, {
    name: 'VISA Tokenization', subMenu: [
      {
        name: 'Dashboard'
      },
      {
        name: 'File History'
      },
      {
        name: 'Transaction History'
      }
    ]
  }, {
    name: 'Pay@', subMenu: [
      {
        name: 'Dashboard'
      },
      {
        name: 'File History'
      },
      {
        name: 'Transaction History'
      }
    ]
  }, {
    name: 'Rapid Payment', subMenu: [
      {
        name: 'Dashboard'
      },
      {
        name: 'File History'
      },
      {
        name: 'Transaction History'
      }
    ]
  }],
  visable: true
}, {
  name: 'Planned', subMenu: [{
    name: 'AVS Realtime', subMenu: [
      {
        name: 'Dashboard'
      },
      {
        name: 'File History'
      },
      {
        name: 'Transaction History'
      }
    ]
  }, {
    name: 'RTC', subMenu: [
      {
        name: 'Dashboard',
      },
      {
        name: 'File History'
      },
      {
        name: 'Transaction History'
      }
    ]
  }],
  visable: false
}]

export default function MainContent() {
  const { isMenuOpen } = useMenu();
  return (
    <div className={`app-container ${isMenuOpen ? "" : "full"}`}  style={{ marginBottom: '10px' }}>
      <SideMenu menuOptions={menu} />
      <div className="main-content">
    
          <EftRealtimeDashboard />

     </div>
    </div>
  )
}
