// GISDataShow.h : GISDataShow 应用程序的主头文件
//
#pragma once

#ifndef __AFXWIN_H__
	#error "在包含此文件之前包含“stdafx.h”以生成 PCH 文件"
#endif

#include "resource.h"       // 主符号


// CGISDataShowApp:
// 有关此类的实现，请参阅 GISDataShow.cpp
//

class CGISDataShowApp : public CWinApp
{
public:
	CGISDataShowApp();

private:
	 ULONG_PTR m_gdiplusToken;
// 重写
public:
	virtual BOOL InitInstance();
    virtual int ExitInstance();
// 实现
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CGISDataShowApp theApp;