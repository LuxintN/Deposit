﻿using System;
using System.Collections.Generic;
using DomainLogic.Model;

namespace DomainLogic.Handlers
{
    public interface IInterestPaymentHandler : IDisposable
    {
        List<Deposit> GetActiveDeposits();
        string GetDepositStateName(int depositId);
        void ExtendDeposit(int depositId, DateTime today);
        void SetLastInterestPaymentDate(int depositId, DateTime date);
        void SetDepositState(int depositId, string stateName);
        void AddInterest(int depositId);
    }
}